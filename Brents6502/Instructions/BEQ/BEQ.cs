namespace Brents6502.Instructions.BEQ
{
    public class BEQ : IInstruction
    {
        public byte OperationCode => 0xF0;
        public string Mnemonic => "BEQ";
        public InstructionType ArgType => InstructionType.Address;
        public int AffectedFlags => 0;
        public int Clocks => 1;
        public int SkippedClocks => 1;
        public int PageBoundaryClocks => 1;
    }
}
