using Assemble6502._6502;

namespace Assemble6502.Instructions.SEC
{
    public class SEC : IInstruction
    {
        public byte OperationCode => 0x38;
        public string Mnemonic => "SEC";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => (int)ProcessorFlags.Carry;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
