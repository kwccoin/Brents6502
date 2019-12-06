using Assemble6502._6502;

namespace Assemble6502.Instructions.LDA
{
    public abstract class LDA : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "LDA";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class LDA_Immediate : LDA
    {
        public override byte OperationCode => 0xA9;
        public override InstructionType ArgType => InstructionType.Literal;
        public override int Clocks => 2;
    }

    public class LDA_ZeroPage : LDA
    {
        public override byte OperationCode => 0xA5;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class LDA_ZeroPage_X : LDA
    {
        public override byte OperationCode => 0xB5;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 4;
    }

    public class LDA_Absolute : LDA
    {
        public override byte OperationCode => 0xAD;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }

    public class LDA_Absolute_X : LDA
    {
        public override byte OperationCode => 0xBD;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class LDA_Absolute_Y : LDA
    {
        public override byte OperationCode => 0xB9;
        public override InstructionType ArgType => InstructionType.AddressY;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class LDA_Indirect_X : LDA
    {
        public override byte OperationCode => 0xA1;
        public override InstructionType ArgType => InstructionType.IndirectX;
        public override int Clocks => 6;
    }

    public class LDA_Indirect_Y : LDA
    {
        public override byte OperationCode => 0xB1;
        public override InstructionType ArgType => InstructionType.IndirectY;
        public override int Clocks => 5;
        public override int PageBoundaryClocks => 1;
    }
}