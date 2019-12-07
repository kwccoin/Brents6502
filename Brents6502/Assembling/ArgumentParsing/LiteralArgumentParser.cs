using System;

namespace Brents6502.Assembling.ArgumentParsing
{
    public class LiteralArgumentParser : IArgumentParser
    {
        public byte[] GetBytes(IArgumentSymbol symbol)
        {
            string src = symbol.Source.Remove(0, 1);
            int val;
            if (src[0] == '$')
            {
                if (src.Length > 3)
                    throw new Exception($"The hexidecimal argument on line {symbol.LineNumber} is invalid. It should represent a single byte ($00-$FF)");
                val = Convert.ToInt32(src.Substring(1), 16);
            }
            else
                val = Convert.ToInt32(src);
            if (val > byte.MaxValue)
                throw new Exception($"The value of the argument on {symbol.LineNumber} is too large, it should be between 0-{byte.MaxValue}");
            return new byte[1] { (byte)val };
        }

        public bool ShouldHandle(IArgumentSymbol symbol)
        {
            return ArgumentSymbol.RegexLiteral.IsMatch(symbol.Source);
        }
    }
}
