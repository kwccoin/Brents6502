using Assemble6502._6502;

namespace Assemble6502.Instructions.ADC
{
    public abstract class ADC : IInstruction
    {
        public string Mnemonic => "ADC";
        public abstract byte OperationCode { get; }
        public abstract InstructionType ArgType { get; }
        public virtual int SkippedClocks => 0;
        public virtual int PageBoundaryClocks => 0;

        public int AffectedFlags => (int)(ProcessorFlags.Negative
            | ProcessorFlags.Overflow
            | ProcessorFlags.Zero
            | ProcessorFlags.Carry);

        public abstract int Clocks { get; }
    }

    public class ADC_Immediate : ADC
    {
        public override byte OperationCode => 0x69;
        public override InstructionType ArgType => InstructionType.Literal;
        public override int Clocks => 2;
    }

    public class ADC_ZeroPage : ADC
    {
        public override byte OperationCode => 0x65;
        public override InstructionType ArgType => InstructionType.ZeroPage;
        public override int Clocks => 3;
    }

    public class ADC_ZeroPage_X : ADC
    {
        public override byte OperationCode => 0x75;
        public override InstructionType ArgType => InstructionType.ZeroPageX;
        public override int Clocks => 4;
    }

    public class ADC_Absolute : ADC
    {
        public override byte OperationCode => 0x6D;
        public override InstructionType ArgType => InstructionType.Address;
        public override int Clocks => 4;
    }

    public class ADC_Absolute_X : ADC
    {
        public override byte OperationCode => 0x7D;
        public override InstructionType ArgType => InstructionType.AddressX;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class ADC_Absolute_Y : ADC
    {
        public override byte OperationCode => 0x79;
        public override InstructionType ArgType => InstructionType.AddressY;
        public override int Clocks => 4;
        public override int PageBoundaryClocks => 1;
    }

    public class ADC_Indirect_X : ADC
    {
        public override byte OperationCode => 0x61;
        public override InstructionType ArgType => InstructionType.IndirectX;
        public override int Clocks => 6;
    }

    public class ADC_Indirect_Y : ADC
    {
        public override byte OperationCode => 0x71;
        public override InstructionType ArgType => InstructionType.IndirectY;
        public override int Clocks => 5;
        public override int PageBoundaryClocks => 1;
    }
}
