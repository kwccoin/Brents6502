using Assemble6502._6502;
using Brents6502.Assembling;
using System;
using System.Collections.Generic;
using System.IO;

namespace Assemble6502
{
    class Program
    {
        private static void Main(string[] args)
        {
            string sourceFile = args[0];
            SourceCode source = new SourceCode(sourceFile);

            InstructionLocater locater = new InstructionLocater();
            List<Instruction> assemblyLines = new List<Instruction>();
            List<Label> labels = new List<Label>();
            List<Define> definitions = new List<Define>();
            List<List<string>> dcbBytes = new List<List<string>>();

            ushort address = 0;
            ushort addrFrom = 0x0600;
            for (int i = 0; i < source.Lines.Count; i++)
            {
                int lineNumber = i + 1;
                if (string.IsNullOrEmpty(source.Lines[i]))
                    continue;

                if (source.Lines[i].StartsWith("*=$"))
                    addrFrom = Convert.ToUInt16(source.Lines[i].Remove(0, 3), 16);
                else if (source.Lines[i].ToLower().StartsWith("define"))
                    definitions.Add(new Define(source.Lines[i], lineNumber)
                    {
                        AddressFrom = addrFrom
                    });
                else if (source.Lines[i].EndsWith(':'))
                    labels.Add(new Label(source.Lines[i], lineNumber, address)
                    {
                        AddressFrom = addrFrom
                    });
                else
                {
                    string cpy = source.Lines[i];
                    if (source.Lines[i].StartsWith("DCB"))
                        cpy = cpy.Replace(',', ' ');
                    Instruction line = new Instruction(cpy, lineNumber, address, locater, definitions)
                    {
                        AddressFrom = addrFrom
                    };
                    assemblyLines.Add(line);

                    int byteCount = 0;
                    if (line.Command.Mnemonic == "DCB")
                    {
                        List<string> parts = new List<string>(cpy.Split(' '));
                        parts.RemoveAt(0);
                        byteCount = parts.Count;
                        dcbBytes.Add(parts);
                    }
                    else
                        byteCount += line.Size;

                    if (byteCount + address > ushort.MaxValue)
                        throw new Exception($"Out of memory. Your instructions have gone beyond address {ushort.MaxValue}");
                    address += (ushort)byteCount;
                }
            }

            int dcbBytesCounter = 0;
            List<byte> byteCode = new List<byte>();
            for (int i = 0; i < assemblyLines.Count; i++)
            {
                if (assemblyLines[i].Command.Mnemonic == "DCB")
                {
                    List<string> dcb = dcbBytes[dcbBytesCounter++];
                    foreach (string b in dcb)
                    {
                        // TODO:  Probably should make sure both are [0-9a-fA-F]
                        if (b[0] != '$' || b.Length != 3)
                            throw new Exception($"DCB expects hexadecimal arguments such as $F3 or $02 on line {assemblyLines[i].LineNumber}");
                        byteCode.Add(Convert.ToByte(b.Remove(0, 1), 16));
                    }
                    continue;
                }
                else if (assemblyLines[i].Argument != null)
                {
                    string prefix = "";
                    string argSrc = assemblyLines[i].Argument.Source;
                    if (argSrc.StartsWith("#>") || argSrc.StartsWith("#<"))
                    {
                        prefix = argSrc.Substring(0, 2);
                        argSrc = argSrc.Remove(0, 2);
                    }

                    for (int j = 0; j < labels.Count; j++)
                    {
                        if (labels[j].Source == argSrc)
                        {
                            if (assemblyLines[i].Command.Mnemonic[0] == 'B')
                            {
                                ushort instructionPos = (ushort)(assemblyLines[i].Address + assemblyLines[i].Size);
                                if (Math.Abs(labels[j].Address - assemblyLines[i].Address) > byte.MaxValue)
                                    throw new Exception($"A branch can't be beyond 255 bytes from the calling line {assemblyLines[i].LineNumber}");
                                byte addr = (byte)(labels[j].Address - instructionPos);
                                assemblyLines[i].Argument.ChangeSource($"{prefix}${addr.ToString("X2")}");
                            }
                            else
                            {
                                ushort addr = (ushort)(labels[j].AddressFrom + labels[j].Address);
                                assemblyLines[i].Argument.ChangeSource($"{prefix}${addr.ToString("X4")}");
                            }
                            break;
                        }
                    }

                    if (assemblyLines[i].Argument.Source.StartsWith("#>")
                        || assemblyLines[i].Argument.Source.StartsWith("#<"))
                    {
                        throw new Exception($"Invalid argumen to instruction {assemblyLines[i].Command.Mnemonic} on line {assemblyLines[i].LineNumber}");
                    }
                }
                byteCode.AddRange(assemblyLines[i].GetLineBytes());
            }

            string outFileName = Path.GetFileName(sourceFile);
            int extensionPos = outFileName.LastIndexOf('.');
            if (extensionPos >= 0)
                outFileName = outFileName.Substring(0, extensionPos);
            File.WriteAllBytes(outFileName + ".prg", byteCode.ToArray());

            //File.WriteAllText("instruction.md", locater.ToString());

            // TODO:  Remove this part
            //string n = Path.GetFileName(sourceFile);
            //string p = Path.GetFullPath(sourceFile);
            //string cmp = File.ReadAllText(p.Remove(p.Length - n.Length) + "snake-hex.txt");
            //string[] cmpHex = cmp.Split(' ');
            //List<byte> cmpByteCode = new List<byte>();
            //foreach (string h in cmpHex)
            //{
            //    cmpByteCode.Add(Convert.ToByte(h, 16));
            //}
            //for (int i = 0; i < byteCode.Count; i++)
            //{
            //    if (byteCode[i] != cmpByteCode[i])
            //        throw new Exception($"The assembled bytes do not match the snake bytes at byte {i}");
            //}
            //if (byteCode.Count != cmpByteCode.Count)
            //    throw new Exception($"The assembled bytes are not the same length as the snake bytes {byteCode.Count}/cmpByteCode.Count");
        }
    }
}
