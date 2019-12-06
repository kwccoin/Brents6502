using Assemble6502._6502;

namespace Assemble6502.Instructions.BIT
{
    public abstract class BIT : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "BIT";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Overflow | ProcessorFlags.Zero);
        public abstract int Clocks { get; }
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }

    public class BIT_ZeroPage : BIT
    {
        public override byte OperationCode => 0x24;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class BIT_Absolute : BIT
    {
        public override byte OperationCode => 0x2C;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 3;
    }
}
