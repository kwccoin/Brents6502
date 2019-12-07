using System;

namespace Brents6502.Assembling.ArgumentParsing
{
    public class IndirectXArgumentParser : IArgumentParser
    {
        public byte[] GetBytes(IArgumentSymbol symbol)
        {
            //($00),X
            string src = symbol.Source.Substring(2, 2);
            return new byte[1] { Convert.ToByte(src, 16) };
        }

        public bool ShouldHandle(IArgumentSymbol symbol)
        {
            return ArgumentSymbol.RegexIndirectX.IsMatch(symbol.Source);
        }
    }
}
