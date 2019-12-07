namespace Brents6502.Instructions.TYA
{
    public class TYA : IInstruction
    {
        public byte OperationCode => 0x98;
        public string Mnemonic => "TYA";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
