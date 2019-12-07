namespace Brents6502.Assembling.Tokens
{
    public interface ITokenReplacement
    {
        string Token { get; set; }
        string Replacement { get; set; }
        void ReplaceToken(ISymbol symbol);
    }
}
