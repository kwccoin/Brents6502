namespace Assemble6502.Instructions.PLP
{
    public class PLP : IInstruction
    {
        public byte OperationCode => 0x28;
        public string Mnemonic => "PLP";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => 0;
        public int Clocks => 4;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
