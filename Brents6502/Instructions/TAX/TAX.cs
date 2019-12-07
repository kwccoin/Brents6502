namespace Brents6502.Instructions.TAX
{
    public class TAX : IInstruction
    {
        public byte OperationCode => 0xAA;
        public string Mnemonic => "TAX";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
