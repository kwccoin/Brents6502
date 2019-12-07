using Brents6502.Assembling;

namespace Brents6502.Instructions.SEI
{
    public class SEI : IInstruction
    {
        public byte OperationCode => 0x78;
        public string Mnemonic => "SEI";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => (int)ProcessorFlags.InterruptDisable;
        public int Clocks => 2;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
