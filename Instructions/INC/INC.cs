using Assemble6502._6502;

namespace Assemble6502.Instructions.INC
{
    public abstract class INC : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "INC";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class INC_ZeroPage : INC
    {
        public override byte OperationCode => 0xE6;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 5;
    }

    public class INC_ZeroPage_X : INC
    {
        public override byte OperationCode => 0xF6;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 6;
    }

    public class INC_Absolute : INC
    {
        public override byte OperationCode => 0xEE;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 6;
    }

    public class INC_Absolute_X : INC
    {
        public override byte OperationCode => 0xFE;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 7;
    }
}