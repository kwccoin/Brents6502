using System;

namespace Brents6502.Assembling.ArgumentParsing
{
    public class IndirectYArgumentParser : IArgumentParser
    {
        public byte[] GetBytes(IArgumentSymbol symbol)
        {
            //($00),Y
            string src = symbol.Source.Substring(2, 2);
            return new byte[1] { Convert.ToByte(src, 16) };
        }

        public bool ShouldHandle(IArgumentSymbol symbol)
        {
            return ArgumentSymbol.RegexIndirectY.IsMatch(symbol.Source);
        }
    }
}
