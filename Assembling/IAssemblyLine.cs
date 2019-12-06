using System.Collections.Generic;

namespace Assemble6502._6502
{
    public interface IAssemblyLine
    {
        string Source { get; }
        ushort Address { get; }
        byte Size { get; }
        int LineNumber { get; }
        ushort AddressFrom { get; set; }
        List<byte> GetLineBytes();
    }
}
