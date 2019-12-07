using Brents6502.Assembling;

namespace Brents6502.Instructions.DEC
{
    public abstract class DEC : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "DEC";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class DEC_ZeroPage : DEC
    {
        public override byte OperationCode => 0xC6;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 5;
    }

    public class DEC_ZeroPage_X : DEC
    {
        public override byte OperationCode => 0xD6;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 6;
    }

    public class DEC_Absolute : DEC
    {
        public override byte OperationCode => 0xCE;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 6;
    }

    public class DEC_Absolute_X : DEC
    {
        public override byte OperationCode => 0xDE;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 7;
    }
}