namespace Brents6502.Instructions.STY
{
    public abstract class STY : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "STY";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => 0;
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class STY_ZeroPage : STY
    {
        public override byte OperationCode => 0x84;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class STY_ZeroPageX : STY
    {
        public override byte OperationCode => 0x94;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 4;
    }

    public class STY_Absolute : STY
    {
        public override byte OperationCode => 0x8C;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }
}