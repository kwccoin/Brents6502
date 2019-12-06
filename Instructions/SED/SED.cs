using Assemble6502._6502;

namespace Assemble6502.Instructions.SED
{
    public class SED : IInstruction
    {
        public byte OperationCode => 0xF8;
        public string Mnemonic => "SED";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => (int)ProcessorFlags.Decimal;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
