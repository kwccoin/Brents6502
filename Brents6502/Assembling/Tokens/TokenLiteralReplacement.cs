namespace Brents6502.Assembling.Tokens
{
    public class TokenLiteralReplacement : ITokenReplacement
    {
        public string Token { get; set; }
        public string Replacement { get; set; }

        public void ReplaceToken(ISymbol symbol)
        {
            if (symbol.Source[0] == '#' && symbol.Source.Substring(1) == Token)
                symbol.SetSource($"#{Replacement}");
        }
    }
}
