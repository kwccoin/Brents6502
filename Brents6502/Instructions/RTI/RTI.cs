using Brents6502.Assembling;

namespace Brents6502.Instructions.RTI
{
    public class RTI : IInstruction
    {
        public byte OperationCode => 0x40;
        public string Mnemonic => "RTI";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => (int)(ProcessorFlags.B0 | ProcessorFlags.B1
            | ProcessorFlags.Carry | ProcessorFlags.Decimal | ProcessorFlags.InterruptDisable
            | ProcessorFlags.Negative | ProcessorFlags.Overflow | ProcessorFlags.Zero);
        public int Clocks => 6;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
