using Assemble6502._6502;

namespace Assemble6502.Instructions.RTS
{
    public class RTS : IInstruction
    {
        public byte OperationCode => 0x60;
        public string Mnemonic => "RTS";
        public InstructionType ArgType => InstructionType.None;
        public int AffectedFlags => (int)(ProcessorFlags.B0 | ProcessorFlags.B1
            | ProcessorFlags.Carry | ProcessorFlags.Decimal | ProcessorFlags.InterruptDisable
            | ProcessorFlags.Negative | ProcessorFlags.Overflow | ProcessorFlags.Zero);
        public int Clocks => 6;
        public int SkippedClocks => 0;
        public int PageBoundaryClocks => 0;
    }
}
