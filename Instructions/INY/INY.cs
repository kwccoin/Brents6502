namespace Assemble6502.Instructions.INY
{
    public class INY : IInstruction
    {
        public byte OperationCode => 0xC8;
        public string Mnemonic => "INY";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
