namespace Assemble6502.Instructions.BPL
{
    public class BPL : IInstruction
    {
        public byte OperationCode => 0x10;
        public string Mnemonic => "BPL";
        public InstructionType ArgType => InstructionType.Address;
        public int AffectedFlags => 0;
        public int Clocks => 1;
        public int SkippedClocks => 1;
        public int PageBoundaryClocks => 1;
    }
}
