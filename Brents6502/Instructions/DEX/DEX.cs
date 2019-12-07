namespace Brents6502.Instructions.DEX
{
    public class DEX : IInstruction
    {
        public byte OperationCode => 0xCA;
        public string Mnemonic => "DEX";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
