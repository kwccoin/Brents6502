using System.Collections.Generic;

namespace Brents6502.Assembling
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
