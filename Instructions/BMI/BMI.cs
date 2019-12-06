namespace Assemble6502.Instructions.BMI
{
    public class BMI : IInstruction
    {
        public byte OperationCode => 0x30;
        public string Mnemonic => "BMI";
        public InstructionType ArgType => InstructionType.Address;
        public int AffectedFlags => 0;
        public int Clocks => 1;
        public int SkippedClocks => 1;
        public int PageBoundaryClocks => 1;
    }
}
