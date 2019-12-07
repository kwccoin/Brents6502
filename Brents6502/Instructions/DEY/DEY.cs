namespace Brents6502.Instructions.DEY
{
    public class DEY : IInstruction
    {
        public byte OperationCode => 0x88;
        public string Mnemonic => "DEY";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
