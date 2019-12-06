namespace Assemble6502.Instructions.STA
{
    public abstract class STA : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "STA";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => 0;
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class STA_ZeroPage : STA
    {
        public override byte OperationCode => 0x85;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class STA_ZeroPage_X : STA
    {
        public override byte OperationCode => 0x95;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 4;
    }

    public class STA_Absolute : STA
    {
        public override byte OperationCode => 0x8D;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }

    public class STA_Absolute_X : STA
    {
        public override byte OperationCode => 0x9D;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 5;
    }

    public class STA_Absolute_Y : STA
    {
        public override byte OperationCode => 0x99;
        public override InstructionType ArgType => InstructionType.AddressY;
        public override int Clocks => 5;
    }

    public class STA_Indirect_X : STA
    {
        public override byte OperationCode => 0x81;
        public override InstructionType ArgType => InstructionType.IndirectX;
        public override int Clocks => 6;
    }

    public class STA_Indirect_Y : STA
    {
        public override byte OperationCode => 0x91;
        public override InstructionType ArgType => InstructionType.IndirectY;
        public override int Clocks => 6;
    }
}