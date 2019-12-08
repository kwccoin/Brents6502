using Brents6502.Assembling.ArgumentParsing;
using Brents6502.Assembling.LineAnalysis;
using Brents6502.Assembling.LineProcessing;
using Brents6502.Assembling.Repositories;
using Brents6502.Instructions;
using System;
using System.Collections.Generic;
using System.IO;

namespace Brents6502.Assembling
{
    public class SourceCode
    {
        private readonly InstructionLocater _instructionLocater = new InstructionLocater();
        private readonly List<ILineAnalyzer> _lineAnalyzers = new List<ILineAnalyzer>();
        private readonly List<ILineProcessor> _linePreProcessors = new List<ILineProcessor>();
        private readonly List<ILineProcessor> _linePostProcessors = new List<ILineProcessor>();
        private readonly IDefineRepository _defineRepository = new DefineRepository();
        private readonly ILabelRepository _labelRepository = new LabelRepository();
        private readonly List<IArgumentParser> _argumentParsers = new List<IArgumentParser>();
        private readonly List<Line> _lines = new List<Line>();
        private List<string> _lineSrcs = new List<string>();
        private ushort _address = 0;

        public SourceCode()
        {
            _lineAnalyzers.Add(new DefineLineAnalyzer(_defineRepository));
            _lineAnalyzers.Add(new LabelLineAnalyzer(_labelRepository));

            _linePreProcessors.Add(new DefineLineProcessor(_defineRepository));
            _linePostProcessors.Add(new LabelLineProcessor(_labelRepository));

            _argumentParsers.Add(new LiteralArgumentParser());
            _argumentParsers.Add(new AddressArgumentParser());
            _argumentParsers.Add(new AddressXArgumentParser());
            _argumentParsers.Add(new AddressYArgumentParser());
            _argumentParsers.Add(new IndirectArgumentParser());
            _argumentParsers.Add(new IndirectXArgumentParser());
            _argumentParsers.Add(new IndirectYArgumentParser());
            _argumentParsers.Add(new ZeroPageArgumentParser());
            _argumentParsers.Add(new ZeroPageXArgumentParser());
            _argumentParsers.Add(new ZeroPageYArgumentParser());

            //File.WriteAllText("instruction.md", _instructionLocater.ToString());
        }

        public List<byte> ProcessCode(string asmFilePath)
        {
            ReadFileLines(asmFilePath);
            CleanUpSourceCode();
            RunLineAnalysis();
            RunPreProcessorsOnLines();
            SetupAddressing();
            RunPostProcessorsOnLines();
            return LinesToByteCode();
        }

        private void CleanUpSourceCode()
        {
            for (int i = 0; i < _lineSrcs.Count; i++)
            {
                _lineSrcs[i] = _lineSrcs[i].Trim();
                _lineSrcs[i] = RemoveComment(_lineSrcs[i]);
                _lineSrcs[i] = ReplaceInLine(_lineSrcs[i], "  ", " ");
                _lineSrcs[i] = ReplaceInLine(_lineSrcs[i], ", ", ",");
                _lineSrcs[i] = ReplaceInLine(_lineSrcs[i], "( ", "(");
                _lineSrcs[i] = ReplaceInLine(_lineSrcs[i], " )", ")");
            }
        }

        private void ReadFileLines(string filePath)
        {
            string contents = File.ReadAllText(filePath);
            contents = contents.Replace("\r", "").Replace("\t", " ");
            _lineSrcs = new List<string>(contents.Split('\n'));
        }

        private string RemoveComment(string line)
        {
            int comment = line.IndexOf(';');
            if (comment >= 0)
                line = line.Remove(comment).Trim();
            return line;
        }

        private string ReplaceInLine(string line, string from, string to)
        {
            while (line.Contains(from))
            {
                line = line.Replace(from, to);
            }
            return line;
        }

        private void RunLineAnalysis()
        {
            var parser = new SymbolParser();
            for (int i = 0; i < _lineSrcs.Count; i++)
            {
                bool isNotExecutableLine = false;
                if (_lineSrcs[i].Length == 0)
                    isNotExecutableLine = true;
                else if (_lineSrcs[i].StartsWith("*=$"))
                    isNotExecutableLine = true;
                else
                {
                    foreach (var a in _lineAnalyzers)
                    {
                        if (a.ShouldHandle(_lineSrcs[i]))
                        {
                            a.HandleLine(_lineSrcs[i]);
                            isNotExecutableLine = true;
                            break;
                        }
                    }
                }
                if (isNotExecutableLine)
                    _lines.Add(new Line { Source = _lineSrcs[i], LineNumber = i + 1 });
                else
                    _lines.Add(parser.ParseAssemblyLine(_lineSrcs[i], i + 1));
            }
        }

        private void RunPreProcessorsOnLines()
        {
            for (int i = 0; i < _lines.Count; i++)
            {
                if (_lines[i].Instruction == null)
                    continue;
                foreach (var p in _linePreProcessors)
                    p.ProcessLine(_lines[i]);
            }
        }


        private void SetupAddressing()
        {
            ushort programAddress = 0x0600;
            foreach (var l in _lines)
            {
                if (l.Instruction == null)
                {
                    // TODO:  Use a regex for this
                    if (l.Source.StartsWith("*=$"))
                    {
                        string addr = l.Source.Substring(3);
                        programAddress = Convert.ToUInt16(addr, 16);
                    }
                    // TODO:  This special behavior is to give labels addresses
                    // I need to find a way to make this more abstract
                    if (l.Source.EndsWith(':'))
                    {
                        string label = l.Source.Remove(l.Source.Length - 1);
                        _labelRepository.SetAddress(label, (ushort)(programAddress + _address));
                    }
                }
                else
                    l.SetupAddresses(programAddress, ref _address);

                if (programAddress + _address > ushort.MaxValue)
                    throw new Exception($"The program address was set to *=${programAddress.ToString("X4")} and the instruction address has now gone beyond ${ushort.MaxValue}");
            }
        }

        private void RunPostProcessorsOnLines()
        {
            for (int i = 0; i < _lines.Count; i++)
            {
                if (_lines[i].Instruction == null)
                    continue;
                foreach (var p in _linePostProcessors)
                    p.ProcessLine(_lines[i]);
                // TODO:  If the line is mal-formed it should throw an exception
            }
        }

        private List<byte> LinesToByteCode()
        {
            List<byte> byteCode = new List<byte>(_address);
            foreach (var l in _lines)
            {
                if (l.Instruction == null)
                    continue;
                IInstruction i = _instructionLocater.GetInstructionForLine(l);
                // TODO:  This should be abstracted away
                if (i.Mnemonic != "DCB")
                    byteCode.Add(i.OperationCode);
                foreach (var a in l.Arguments)
                {
                    // TODO:  This is a hack and branching needs some love
                    if (l.Instruction.Source.ToUpper()[0] == 'B' && l.Instruction.Source.ToUpper() != "BIT")
                    {
                        ushort val = Convert.ToUInt16(a.Source.Substring(1), 16);
                        // Branches don't include thier own length
                        byte relative = (byte)(val - l.Instruction.Address - l.GetByteCount());
                        byteCode.Add(relative);
                        continue;
                    }

                    foreach (var p in _argumentParsers)
                    {
                        if (p.ShouldHandle(a))
                        {
                            byteCode.AddRange(p.GetBytes(a));
                            break;
                        }
                    }
                }
            }
            return byteCode;
        }
    }
}
