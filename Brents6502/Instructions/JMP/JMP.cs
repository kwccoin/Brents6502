namespace Brents6502.Instructions.JMP
{
    public abstract class JMP : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "JMP";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => 0;
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class JMP_Absolute : JMP
    {
        public override byte OperationCode => 0x4C;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 3;
    }

    public class JMP_Indirect : JMP
    {
        public override byte OperationCode => 0x6C;
        public override InstructionType ArgType => InstructionType.Indirect;
        public override int Clocks => 5;
    }
}