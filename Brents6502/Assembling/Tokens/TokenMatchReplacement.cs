namespace Brents6502.Assembling.Tokens
{
    public class TokenMatchReplacement : ITokenReplacement
    {
        public string Token { get; set; }
        public string Replacement { get; set; }

        public void ReplaceToken(ISymbol symbol)
        {
            if (symbol.Source == Token)
                symbol.SetSource(Replacement);
        }
    }
}
