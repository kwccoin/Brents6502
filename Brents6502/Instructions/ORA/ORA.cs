using Brents6502.Assembling;

namespace Brents6502.Instructions.ORA
{
    public abstract class ORA : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "ORA";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Overflow | ProcessorFlags.Zero);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class ORA_Immediate : ORA
    {
        public override byte OperationCode => 0x09;
        public override InstructionType ArgType => InstructionType.Literal;
        public override int Clocks => 2;
    }

    public class ORA_ZeroPage : ORA
    {
        public override byte OperationCode => 0x05;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class ORA_ZeroPage_X : ORA
    {
        public override byte OperationCode => 0x15;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 4;
    }

    public class ORA_Absolute : ORA
    {
        public override byte OperationCode => 0x0D;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }

    public class ORA_Absolute_X : ORA
    {
        public override byte OperationCode => 0x1D;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class ORA_Absolute_Y : ORA
    {
        public override byte OperationCode => 0x19;
        public override InstructionType ArgType => InstructionType.AddressY;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class ORA_Indirect_X : ORA
    {
        public override byte OperationCode => 0x01;
        public override InstructionType ArgType => InstructionType.IndirectX;
        public override int Clocks => 6;
    }

    public class ORA_Indirect_Y : ORA
    {
        public override byte OperationCode => 0x11;
        public override InstructionType ArgType => InstructionType.IndirectY;
        public override int Clocks => 5;
        public override int PageBoundaryClocks => 1;
    }
}
