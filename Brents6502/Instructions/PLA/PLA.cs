namespace Brents6502.Instructions.PLA
{
    public class PLA : IInstruction
    {
        public byte OperationCode => 0x68;
        public string Mnemonic => "PLA";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 4;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
