using Brents6502.Assembling;

namespace Brents6502.Instructions.CLI
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
