namespace Brents6502.Instructions.STX
{
    public abstract class STX : IInstruction
    {
        public abstract byte OperationCode { get; }
        public string Mnemonic => "STX";
        public abstract InstructionType ArgType { get; }
        public int AffectedFlags => 0;
        public abstract int Clocks { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;
    }

    public class STX_ZeroPage : STX
    {
        public override byte OperationCode => 0x86;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class STX_ZeroPage_Y : STX
    {
        public override byte OperationCode => 0x96;
        public override InstructionType ArgType => InstructionType.ZeroPageY;
        public override int Clocks => 4;
    }

    public class STX_Absolute : STX
    {
        public override byte OperationCode => 0x8E;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }
}