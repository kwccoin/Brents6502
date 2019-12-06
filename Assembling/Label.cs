using System.Collections.Generic;

namespace Assemble6502._6502
{
    public class Label : IAssemblyLine
    {
        public string Source { get; private set; }
        public ushort Address { get; private set; }
        public int LineNumber { get; private set; }
        public byte Size => 0;
        public ushort AddressFrom { get; set; }

        public Label(string line, int lineNumber, ushort address)
        {
            Source = line.Remove(line.Length - 1);
            Address = address;
            LineNumber = lineNumber;
        }

        public List<byte> GetLineBytes()
        {
            return new List<byte>();
        }
    }
}
