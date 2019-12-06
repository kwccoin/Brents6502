namespace Assemble6502.Instructions.DCB
{
    public class DCB : IInstruction
    {
        public byte OperationCode => 0xFF;
        public string Mnemonic => "DCB";
        public InstructionType ArgType => InstructionType.ZeroPage;
        public int AffectedFlags => 0;
        public int Clocks => 0;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}