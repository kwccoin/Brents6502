using Brents6502.Assembling;

namespace Brents6502.Instructions.ROL
{
    public abstract class ROL : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "ROL";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero | ProcessorFlags.Carry);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class ROL_Default : ROL
    {
        public override byte OperationCode => 0x2A;
        public override InstructionType ArgType => InstructionType.None;
        public override int Clocks => 2;
    }

    public class ROL_Accumulator : ROL
    {
        public override byte OperationCode => 0x2A;
        public override InstructionType ArgType => InstructionType.Accumulator;
        public override int Clocks => 2;
    }

    public class ROL_ZeroPage : ROL
    {
        public override byte OperationCode => 0x26;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 5;
    }

    public class ROL_ZeroPage_X : ROL
    {
        public override byte OperationCode => 0x36;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 6;
    }

    public class ROL_Absolute : ROL
    {
        public override byte OperationCode => 0x2E;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 6;
    }

    public class ROL_Absolute_X : ROL
    {
        public override byte OperationCode => 0x3E;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 7;
    }
}
