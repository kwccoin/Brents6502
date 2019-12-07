using Brents6502.Assembling;

namespace Brents6502.Instructions.EOR
{
    public abstract class EOR : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "EOR";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => (int)(ProcessorFlags.Negative | ProcessorFlags.Zero);
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class EOR_Immediate : EOR
    {
        public override byte OperationCode => 0x49;
        public override InstructionType ArgType => InstructionType.Literal;
        public override int Clocks => 2;
    }

    public class EOR_ZeroPage : EOR
    {
        public override byte OperationCode => 0x45;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class EOR_ZeroPage_X : EOR
    {
        public override byte OperationCode => 0x55;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 4;
    }

    public class EOR_Absolute : EOR
    {
        public override byte OperationCode => 0x4D;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }

    public class EOR_Absolute_X : EOR
    {
        public override byte OperationCode => 0x5D;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class EOR_Absolute_Y : EOR
    {
        public override byte OperationCode => 0x59;
        public override InstructionType ArgType => InstructionType.AddressY;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class EOR_Indirect_X : EOR
    {
        public override byte OperationCode => 0x41;
        public override InstructionType ArgType => InstructionType.IndirectX;
        public override int Clocks => 6;
    }

    public class EOR_Indirect_Y : EOR
    {
        public override byte OperationCode => 0x51;
        public override InstructionType ArgType => InstructionType.IndirectY;
        public override int Clocks => 5;
        public override int PageBoundaryClocks => 1;
    }
}