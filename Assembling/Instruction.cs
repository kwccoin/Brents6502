using Assemble6502.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assemble6502._6502
{
    public class Instruction : IAssemblyLine
    {
        public string Source { get; private set; }
        public ushort Address { get; private set; }
        public int LineNumber { get; private set; }
        public byte Size => InstructionSize();
        private readonly IInstruction _instruction;
        private readonly Arg _argument = null;
        public Arg Argument => _argument;
        public IInstruction Command => _instruction;
        public ushort AddressFrom { get; set; }

        public Instruction(string line, int lineNumber, ushort address,
            InstructionLocater instructionLocator, List<Define> definitions)
        {
            Source = line;
            LineNumber = lineNumber;
            Address = address;
            string[] parts = line.Split(' ');
            var matching = instructionLocator.GetInstructionForMnemonic(parts[0], LineNumber);

            if (parts.Length > 1)
            {
                _argument = new Arg(parts[1]);
                for (int i = 0; i < definitions.Count; i++)
                {
                    if (definitions[i].FindAndReplace(_argument))
                        break;
                }
                try
                {
                    _instruction = matching.First(m => m.ArgType == _argument.Type);
                }
                catch
                {
                    throw new Exception($"The argument to {parts[0]} is not valid on line {lineNumber}");
                }
            }
            else
            {
                try
                {
                    _instruction = matching.First(m => m.ArgType == InstructionType.None);
                }
                catch
                {
                    throw new Exception($"{parts[0]} expects an argument on line {lineNumber}");
                }
            }

        }

        public List<byte> GetLineBytes()
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(_instruction.OperationCode);
            if (_argument != null)
                bytes.AddRange(_argument.GetBytes());
            return bytes;
        }

        private byte InstructionSize()
        {
            InstructionType t = _instruction.ArgType;
            if (t == InstructionType.Address && _instruction.Mnemonic[0] == 'B')
                return 2;

            switch (t)
            {
                case InstructionType.None:
                case InstructionType.Accumulator:
                    return 1;
                case InstructionType.Literal:
                case InstructionType.ZeroPage:
                case InstructionType.ZeroPageX:
                case InstructionType.ZeroPageY:
                case InstructionType.IndirectX:
                case InstructionType.IndirectY:
                    return 2;
                case InstructionType.Address:
                case InstructionType.Indirect:
                case InstructionType.AddressX:
                case InstructionType.AddressY:
                    return 3;
            }
            throw new ArgumentException();
        }
    }
}
