using Assemble6502._6502;

namespace Assemble6502.Instructions.LDX
{
    public abstract class LDX : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "LDX";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class LDX_Immediate : LDX
    {
        public override byte OperationCode => 0xA2;
        public override InstructionType ArgType => InstructionType.Literal;
        public override int Clocks => 2;
    }

    public class LDX_ZeroPage : LDX
    {
        public override byte OperationCode => 0xA6;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class LDX_ZeroPage_Y : LDX
    {
        public override byte OperationCode => 0xB6;
        public override InstructionType ArgType => InstructionType.ZeroPageY;
        public override int Clocks => 4;
    }

    public class LDX_Absolute : LDX
    {
        public override byte OperationCode => 0xAE;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }

    public class LDX_Absolute_Y : LDX
    {
        public override byte OperationCode => 0xBE;
        public override InstructionType ArgType => InstructionType.AddressY;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }
}