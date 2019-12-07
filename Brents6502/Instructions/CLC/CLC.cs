using Brents6502.Assembling;

namespace Brents6502.Instructions.CLC
{
    public class CLC : IInstruction
    {
        public byte OperationCode => 0x18;
        public string Mnemonic => "CLC";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => (int)ProcessorFlags.Carry;
        public int Clocks => 2;
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }
}
