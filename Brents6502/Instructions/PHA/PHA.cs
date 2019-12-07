namespace Brents6502.Instructions.PHA
{
    public class PHA : IInstruction
    {
        public byte OperationCode => 0x48;
        public string Mnemonic => "PHA";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 3;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
