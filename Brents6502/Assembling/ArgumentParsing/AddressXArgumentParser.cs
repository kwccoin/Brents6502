using System;

namespace Brents6502.Assembling.ArgumentParsing
{
    public class AddressXArgumentParser : IArgumentParser
    {
        public byte[] GetBytes(IArgumentSymbol symbol)
        {
            //$0000,X
            string src = symbol.Source.Substring(1, 4);
            ushort val = Convert.ToUInt16(src, 16);
            return BitConverter.GetBytes(val);
        }

        public bool ShouldHandle(IArgumentSymbol symbol)
        {
            return ArgumentSymbol.RegexAddressX.IsMatch(symbol.Source);
        }
    }
}
