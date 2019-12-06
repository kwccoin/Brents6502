namespace Assemble6502.Instructions
{
    public enum InstructionType
    {
        None,
        Address,
        AddressX,
        AddressY,
        Literal,
        Indirect,
        IndirectX,
        IndirectY,
        ZeroPage,
        ZeroPageX,
        ZeroPageY,
        Accumulator
    }
}