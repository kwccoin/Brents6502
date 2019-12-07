using Brents6502.Assembling;

namespace Brents6502.Instructions.LDY
{
    public abstract class LDY : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "LDY";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class LDY_Immediate : LDY
    {
        public override byte OperationCode => 0xA0;
        public override InstructionType ArgType => InstructionType.Literal;
        public override int Clocks => 2;
    }

    public class LDY_ZeroPage : LDY
    {
        public override byte OperationCode => 0xA4;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class LDY_ZeroPage_X : LDY
    {
        public override byte OperationCode => 0xB4;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 4;
    }

    public class LDY_Absolute : LDY
    {
        public override byte OperationCode => 0xAC;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }

    public class LDY_Absolute_X : LDY
    {
        public override byte OperationCode => 0xBC;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }
}