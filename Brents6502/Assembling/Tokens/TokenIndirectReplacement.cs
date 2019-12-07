namespace Brents6502.Assembling.Tokens
{
    public class TokenIndirectReplacement : TokenAddressingReplacement
    {
        protected override string Pattern => "{0},{1}";
        protected override string RegexPattern => @"{0},{1}";

        protected override char GetRegisterLetter(string src)
        {
            return src[src.Length - 1];
        }
    }
}
