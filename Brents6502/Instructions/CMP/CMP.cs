namespace Brents6502.Instructions.CMP
{
    public abstract class CMP : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "CMP";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => 0;
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class CMP_Immediate : CMP
    {
        public override byte OperationCode => 0xC9;
        public override InstructionType ArgType => InstructionType.Literal;
        public override int Clocks => 2;
    }

    public class CMP_ZeroPage : CMP
    {
        public override byte OperationCode => 0xC5;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class CMP_ZeroPage_X : CMP
    {
        public override byte OperationCode => 0xD5;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 4;
    }

    public class CMP_Absolute : CMP
    {
        public override byte OperationCode => 0xCD;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }

    public class CMP_Absolute_X : CMP
    {
        public override byte OperationCode => 0xDD;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class CMP_Absolute_Y : CMP
    {
        public override byte OperationCode => 0xD9;
        public override InstructionType ArgType => InstructionType.AddressY;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class CMP_Indirect_X : CMP
    {
        public override byte OperationCode => 0xC1;
        public override InstructionType ArgType => InstructionType.IndirectX;
        public override int Clocks => 6;
    }

    public class CMP_Indirect_Y : CMP
    {
        public override byte OperationCode => 0xD1;
        public override InstructionType ArgType => InstructionType.IndirectY;
        public override int Clocks => 5;
        public override int PageBoundaryClocks => 1;
    }
}
