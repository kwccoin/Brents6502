using System;

namespace Brents6502.Assembling.ArgumentParsing
{
    public class AddressArgumentParser : IArgumentParser
    {
        public byte[] GetBytes(IArgumentSymbol symbol)
        {
            //$0000
            string src = symbol.Source.Substring(1);
            ushort val = Convert.ToUInt16(src, 16);
            return BitConverter.GetBytes(val);
        }

        public bool ShouldHandle(IArgumentSymbol symbol)
        {
            return ArgumentSymbol.RegexAddress.IsMatch(symbol.Source);
        }
    }
}
