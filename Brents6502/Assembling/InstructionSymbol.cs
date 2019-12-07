namespace Brents6502.Assembling
{
    public class InstructionSymbol : IInstructionSymbol
    {
        public string Source { get; private set; }
        public int LineNumber { get; set; }
        public ushort Address { get; set; }

        public void SetSource(string source)
        {
            Source = source;
        }
    }
}
