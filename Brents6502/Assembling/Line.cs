using Brents6502.Instructions;
using System;

namespace Brents6502.Assembling
{
    public class Line
    {
        public string Source { get; set; }
        public int LineNumber { get; set; }
        public IInstructionSymbol Instruction { get; set; }
        public IArgumentSymbol[] Arguments { get; set; }

        public void SetupAddresses(ushort programAddress, ref ushort address)
        {
            Instruction.Address = (ushort)(programAddress + address++);
            foreach (var a in Arguments)
            {
                a.Address = (ushort)(programAddress + address);
                address += GetArgumentSize(a.GetArgType());
            }
        }

        public int GetByteCount()
        {
            int count = 1;
            foreach (var a in Arguments)
                count += GetArgumentSize(a.GetArgType());
            return count;
        }

        private byte GetArgumentSize(InstructionType t)
        {
            // TODO:  This has special behavior and should figure out an abstract
            // way of handling this problem
            if (t == InstructionType.Address && Instruction.Source.ToUpper()[0] == 'B'
                && Instruction.Source.ToUpper() != "BIT")
            {
                return 1;
            }

            switch (t)
            {
                case InstructionType.Literal:
                case InstructionType.ZeroPage:
                case InstructionType.ZeroPageX:
                case InstructionType.ZeroPageY:
                case InstructionType.IndirectX:
                case InstructionType.IndirectY:
                    return 1;
                case InstructionType.Address:
                case InstructionType.Indirect:
                case InstructionType.AddressX:
                case InstructionType.AddressY:
                    return 2;
            }
            throw new ArgumentException();
        }
    }
}
