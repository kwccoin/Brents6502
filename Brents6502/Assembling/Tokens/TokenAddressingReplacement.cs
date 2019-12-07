using System.Text.RegularExpressions;

namespace Brents6502.Assembling.Tokens
{
    public abstract class TokenAddressingReplacement : ITokenReplacement
    {
        protected abstract string Pattern { get; }
        protected abstract string RegexPattern { get; }
        protected abstract char GetRegisterLetter(string src);

        private Regex _regex;
        private string _token;
        public string Token
        {
            get { return _token; }
            set
            {
                _token = value;
                _regex = new Regex("^" + string.Format(RegexPattern, _token, "[xXyY]") + "$");
            }
        }
        public string Replacement { get; set; }

        public void ReplaceToken(ISymbol symbol)
        {
            if (_regex.IsMatch(symbol.Source))
                symbol.SetSource(string.Format(Pattern, Replacement, GetRegisterLetter(symbol.Source)));
        }
    }
}
