using System;

namespace Brents6502.Assembling.ArgumentParsing
{
    public class ZeroPageArgumentParser : IArgumentParser
    {
        public byte[] GetBytes(IArgumentSymbol symbol)
        {
            //$00
            string src = symbol.Source.Substring(1);
            return new byte[1] { Convert.ToByte(src, 16) };
        }

        public bool ShouldHandle(IArgumentSymbol symbol)
        {
            return ArgumentSymbol.RegexZeroPage.IsMatch(symbol.Source);
        }
    }
}
