using Assemble6502._6502;

namespace Assemble6502.Instructions.CLV
{
    public class CLV : IInstruction
    {
        public byte OperationCode => 0xB8;
        public string Mnemonic => "CLV";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => (int)ProcessorFlags.Overflow;
        public int Clocks => 2;
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }
}
