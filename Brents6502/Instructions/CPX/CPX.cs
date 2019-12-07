using Brents6502.Assembling;

namespace Brents6502.Instructions.CPX
{
    public abstract class CPX : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "CPX";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero | ProcessorFlags.Carry);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class CPX_Immediate : CPX
    {
        public override byte OperationCode => 0xE0;
        public override InstructionType ArgType => InstructionType.Literal;
        public override int Clocks => 2;
    }

    public class CPX_ZeroPage : CPX
    {
        public override byte OperationCode => 0xE4;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class CPX_Absolute : CPX
    {
        public override byte OperationCode => 0xEC;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }
}