namespace Brents6502.Assembling.Tokens
{
    public class TokenHighLowByteReplacement : ITokenReplacement
    {
        public string Token { get; set; }
        public string Replacement { get; set; }

        public void ReplaceToken(ISymbol symbol)
        {
            if ((symbol.Source.StartsWith("#<") || symbol.Source.StartsWith("#>"))
                && symbol.Source.Substring(2) == Token)
            {
                if (symbol.Source[1] == '>')
                    symbol.SetSource($"#{Replacement.Substring(0, 3)}");
                else
                    symbol.SetSource($"#${Replacement.Substring(3, 2)}");
            }
        }
    }
}
