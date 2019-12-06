namespace Assemble6502.Instructions.TXA
{
    public class TXA : IInstruction
    {
        public byte OperationCode => 0x8A;
        public string Mnemonic => "TXA";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
