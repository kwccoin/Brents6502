namespace Brents6502.Instructions.BVS
{
    public class BVS : IInstruction
    {
        public byte OperationCode => 0x70;
        public string Mnemonic => "BVS";
        public InstructionType ArgType => InstructionType.Address;
        public int AffectedFlags => 0;
        public int Clocks => 1;
        public int SkippedClocks => 1;
        public int PageBoundaryClocks => 1;
    }
}
