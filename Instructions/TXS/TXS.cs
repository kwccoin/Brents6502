namespace Assemble6502.Instructions.TXS
{
    public class TXS : IInstruction
    {
        public byte OperationCode => 0x9A;
        public string Mnemonic => "TXS";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
