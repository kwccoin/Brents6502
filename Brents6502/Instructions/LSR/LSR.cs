using Brents6502.Assembling;

namespace Brents6502.Instructions.LSR
{
    public abstract class LSR : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "LSR";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero | ProcessorFlags.Carry);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class LSR_Default : LSR
    {
        public override byte OperationCode => 0x4A;
        public override InstructionType ArgType => InstructionType.None;
        public override int Clocks => 2;
    }

    public class LSR_Accumulator : LSR
    {
        public override byte OperationCode => 0x4A;
        public override InstructionType ArgType => InstructionType.Accumulator;
        public override int Clocks => 2;
    }

    public class LSR_ZeroPage : LSR
    {
        public override byte OperationCode => 0x46;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 5;
    }

    public class LSR_ZeroPage_X : LSR
    {
        public override byte OperationCode => 0x56;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 6;
    }

    public class LSR_Absolute : LSR
    {
        public override byte OperationCode => 0x4E;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 0x4E;
    }

    public class LSR_Absolute_X : LSR
    {
        public override byte OperationCode => 0x5E;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 7;
    }
}
