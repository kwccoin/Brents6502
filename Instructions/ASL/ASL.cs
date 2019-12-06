using Assemble6502._6502;

namespace Assemble6502.Instructions.ASL
{
    public abstract class ASL : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "ASL";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero | ProcessorFlags.Carry);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class ASL_Default : ASL
    {
        public override byte OperationCode => 0x0A;
        public override InstructionType ArgType => InstructionType.None;
        public override int Clocks => 2;
    }

    public class ASL_Accumulator : ASL
    {
        public override byte OperationCode => 0x0A;
        public override InstructionType ArgType => InstructionType.Accumulator;
        public override int Clocks => 2;
    }

    public class ASL_ZeroPage : ASL
    {
        public override byte OperationCode => 0x06;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 5;
    }

    public class ASL_ZeroPage_X : ASL
    {
        public override byte OperationCode => 0x16;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 6;
    }

    public class ASL_Absolute : ASL
    {
        public override byte OperationCode => 0x0E;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 6;
    }

    public class ASL_Absolute_X : ASL
    {
        public override byte OperationCode => 0x1E;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 7;
    }
}
