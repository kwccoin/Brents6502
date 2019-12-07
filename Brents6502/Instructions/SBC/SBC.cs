using Brents6502.Assembling;

namespace Brents6502.Instructions.SBC
{
    public abstract class SBC : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "SBC";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Overflow | ProcessorFlags.Zero | ProcessorFlags.Carry);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class SBC_Immediate : SBC
    {
        public override byte OperationCode => 0xE9;
        public override InstructionType ArgType => InstructionType.Literal;
        public override int Clocks => 2;
    }

    public class SBC_ZeroPage : SBC
    {
        public override byte OperationCode => 0xE5;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class SBC_ZeroPage_X : SBC
    {
        public override byte OperationCode => 0xF5;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 4;
    }

    public class SBC_Absolute : SBC
    {
        public override byte OperationCode => 0xED;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }

    public class SBC_Absolute_X : SBC
    {
        public override byte OperationCode => 0xFD;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class SBC_Absolute_Y : SBC
    {
        public override byte OperationCode => 0xF9;
        public override InstructionType ArgType => InstructionType.AddressY;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class SBC_Indirect_X : SBC
    {
        public override byte OperationCode => 0xE1;
        public override InstructionType ArgType => InstructionType.IndirectX;
        public override int Clocks => 6;
    }

    public class SBC_Indirect_Y : SBC
    {
        public override byte OperationCode => 0xF1;
        public override InstructionType ArgType => InstructionType.IndirectY;
        public override int Clocks => 5;
        public override int PageBoundaryClocks => 1;
    }
}