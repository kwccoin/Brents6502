namespace Brents6502.Instructions.BNE
{
    public class BNE : IInstruction
    {
        public byte OperationCode => 0xD0;
        public string Mnemonic => "BNE";
        public InstructionType ArgType => InstructionType.Address;
        public int AffectedFlags => 0;
        public int Clocks => 1;
        public int SkippedClocks => 1;
        public int PageBoundaryClocks => 1;
    }
}
