namespace Assemble6502.Instructions.NOP
{
    public class NOP : IInstruction
    {
        public byte OperationCode => 0xEA;
        public string Mnemonic => "NOP";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
