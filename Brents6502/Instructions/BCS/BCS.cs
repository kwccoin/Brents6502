namespace Brents6502.Instructions.BCS
{
    public class BCS : IInstruction
    {
        public byte OperationCode => 0xB0;
        public string Mnemonic => "BCS";
        public InstructionType ArgType => InstructionType.Address;
        public int AffectedFlags => 0;
        public int Clocks => 1;
        public int SkippedClocks => 1;
        public int PageBoundaryClocks => 1;
    }
}
