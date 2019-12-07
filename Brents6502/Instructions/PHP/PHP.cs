namespace Brents6502.Instructions.PHP
{
    public class PHP : IInstruction
    {
        public byte OperationCode => 0x08;
        public string Mnemonic => "PHP";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 3;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
