namespace Brents6502.Instructions.BCC
{
    public class BCC : IInstruction
    {
        public byte OperationCode => 0x90;
        public string Mnemonic => "BCC";
        public InstructionType ArgType => InstructionType.Address;
        public int AffectedFlags => 0;
        public int Clocks => 1;
        public int SkippedClocks => 1;
        public int PageBoundaryClocks => 1;
    }
}
