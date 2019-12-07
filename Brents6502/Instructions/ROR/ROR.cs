using Brents6502.Assembling;

namespace Brents6502.Instructions.ROR
{
    public abstract class ROR : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "ROR";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero | ProcessorFlags.Carry);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class ROR_Default : ROR
    {
        public override byte OperationCode => 0x6A;
        public override InstructionType ArgType => InstructionType.None;
        public override int Clocks => 2;
    }

    public class ROR_Accumulator : ROR
    {
        public override byte OperationCode => 0x6A;
        public override InstructionType ArgType => InstructionType.Accumulator;
        public override int Clocks => 2;
    }

    public class ROR_ZeroPage : ROR
    {
        public override byte OperationCode => 0x66;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 5;
    }

    public class ROR_ZeroPage_X : ROR
    {
        public override byte OperationCode => 0x76;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 6;
    }

    public class ROR_Absolute : ROR
    {
        public override byte OperationCode => 0x6E;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 6;
    }

    public class ROR_Absolute_X : ROR
    {
        public override byte OperationCode => 0x7E;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 7;
    }
}
