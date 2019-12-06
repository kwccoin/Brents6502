namespace Assemble6502.Instructions.TAY
{
    public class TAY : IInstruction
    {
        public byte OperationCode => 0xA8;
        public string Mnemonic => "TAY";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
