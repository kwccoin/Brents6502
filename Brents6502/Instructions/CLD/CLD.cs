using Brents6502.Assembling;

namespace Brents6502.Instructions.CLD
{
    public class CLD : IInstruction
    {
        public byte OperationCode => 0xD8;
        public string Mnemonic => "CLD";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => (int)ProcessorFlags.Decimal;
        public int Clocks => 2;
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }
}
