namespace Assemble6502.Instructions.TSX
{
    public class TSX : IInstruction
    {
        public byte OperationCode => 0xBA;
        public string Mnemonic => "TSX";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
