namespace Brents6502.Instructions.JSR
{
    public class JSR : IInstruction
    {
        public byte OperationCode => 0x20;
        public string Mnemonic => "JSR";
        public InstructionType ArgType => InstructionType.Address;
        public int AffectedFlags => 0;
        public int Clocks => 6;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}