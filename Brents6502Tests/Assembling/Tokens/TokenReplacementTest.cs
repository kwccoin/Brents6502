using Brents6502.Assembling;
using Brents6502.Assembling.Tokens;
using FakeItEasy;

namespace Brents6502Tests.Assembling.Tokens
{
    public abstract class TokenReplacementTest
    {
        protected abstract ITokenReplacement Replacer { get; }

        private ISymbol Run(string src, string token, string replace)
        {
            var symbol = A.Fake<ISymbol>();
            var replacer = Replacer;
            A.CallTo(() => symbol.Source).Returns(src);
            replacer.Token = token;
            replacer.Replacement = replace;
            replacer.ReplaceToken(symbol);
            return symbol;
        }

        protected void ShouldFind(string src, string token, string replace, string result)
        {
            ISymbol symbol = Run(src, token, replace);
            A.CallTo(() => symbol.SetSource(A<string>.That.IsEqualTo(result)))
                .MustHaveHappenedOnceExactly();
        }

        protected void ShouldNotFind(string src, string token, string replace)
        {
            ISymbol symbol = Run(src, token, replace);
            A.CallTo(() => symbol.SetSource(A<string>._))
                .MustNotHaveHappened();
        }
    }
}
