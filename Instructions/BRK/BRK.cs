namespace Assemble6502.Instructions.BRK
{
    public class BRK : IInstruction
    {
        public byte OperationCode => 0x00;
        public string Mnemonic => "BRK";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 7;
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }
}
