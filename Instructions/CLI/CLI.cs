using Assemble6502._6502;

namespace Assemble6502.Instructions.CLI
{
    public class CLI : IInstruction
    {
        public byte OperationCode => 0x58;
        public string Mnemonic => "CLI";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => (int)ProcessorFlags.InterruptDisable;
        public int Clocks => 2;
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }
}
