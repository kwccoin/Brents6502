using Assemble6502._6502;

namespace Assemble6502.Instructions.CPY
{
    public abstract class CPY : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "CPY";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero | ProcessorFlags.Carry);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class CPY_Immediate : CPY
    {
        public override byte OperationCode => 0xC0;
        public override InstructionType ArgType => InstructionType.Literal;
        public override int Clocks => 2;
    }

    public class CPY_ZeroPage : CPY
    {
        public override byte OperationCode => 0xC4;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class CPY_Absolute : CPY
    {
        public override byte OperationCode => 0xCC;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }
}