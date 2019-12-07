namespace Brents6502.Assembling
{
    public interface ISymbol
    {
        string Source { get; }
        int LineNumber { get; set; }
        ushort Address { get; set; }
        void SetSource(string source);
    }
}
