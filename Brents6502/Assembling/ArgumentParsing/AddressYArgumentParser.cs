using System;

namespace Brents6502.Assembling.ArgumentParsing
{
    public class AddressYArgumentParser : IArgumentParser
    {
        public byte[] GetBytes(IArgumentSymbol symbol)
        {
            //$0000,Y
            string src = symbol.Source.Substring(1, 4);
            ushort val = Convert.ToUInt16(src, 16);
            return BitConverter.GetBytes(val);
        }

        public bool ShouldHandle(IArgumentSymbol symbol)
        {
            return ArgumentSymbol.RegexAddressY.IsMatch(symbol.Source);
        }
    }
}

