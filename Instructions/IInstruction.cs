namespace Assemble6502.Instructions
{
    public interface IInstruction
    {
        byte OperationCode { get; }
        string Mnemonic { get; }
        InstructionType ArgType { get; }
        int AffectedFlags { get; }
        int Clocks { get; }
        int SkippedClocks { get; }
        int PageBoundaryClocks { get; }
    }
}
