namespace Brents6502.Assembling
{
    public enum ProcessorFlags
    {
        Negative = 0x01,
        Overflow = 0x02,
        B0 = 0x04,
        B1 = 0x08,
        Decimal = 0x10,
        InterruptDisable = 0x20,
        Zero = 0x40,
        Carry = 0x80
    }
}
