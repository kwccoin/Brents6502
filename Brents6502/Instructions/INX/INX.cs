namespace Brents6502.Instructions.INX
{
    public class INX : IInstruction
    {
        public byte OperationCode => 0xE8;
        public string Mnemonic => "INX";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
