using Assemble6502._6502;

namespace Assemble6502.Instructions.AND
{
    public abstract class AND : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "AND";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class AND_Immediate : AND
    {
        public override byte OperationCode => 0x29;
        public override InstructionType ArgType => InstructionType.Literal;
        public override int Clocks => 2;
    }

    public class AND_ZeroPage : AND
    {
        public override byte OperationCode => 0x25;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class AND_ZeroPage_X : AND
    {
        public override byte OperationCode => 0x35;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 4;
    }

    public class AND_Absolute : AND
    {
        public override byte OperationCode => 0x2D;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }

    public class AND_Absolute_X : AND
    {
        public override byte OperationCode => 0x3D;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class AND_Absolute_Y : AND
    {
        public override byte OperationCode => 0x39;
        public override InstructionType ArgType => InstructionType.AddressY;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class AND_Indirect_X : AND
    {
        public override byte OperationCode => 0x21;
        public override InstructionType ArgType => InstructionType.IndirectX;
        public override int Clocks => 6;
    }

    public class AND_Indirect_Y : AND
    {
        public override byte OperationCode => 0x31;
        public override InstructionType ArgType => InstructionType.IndirectY;
        public override int Clocks => 5;
        public override int PageBoundaryClocks => 1;
    }
}
