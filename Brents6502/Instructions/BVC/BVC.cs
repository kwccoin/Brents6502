namespace Brents6502.Instructions.BVC
{
    public class BVC : IInstruction
    {
        public byte OperationCode => 0x50;
        public string Mnemonic => "BVC";
        public InstructionType ArgType => InstructionType.Address;
        public int AffectedFlags => 0;
        public int Clocks => 1;
        public int SkippedClocks => 1;
        public int PageBoundaryClocks => 1;
    }
}
