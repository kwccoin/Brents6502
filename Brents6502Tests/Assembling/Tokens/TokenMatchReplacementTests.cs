using Brents6502.Assembling.Tokens;
using NUnit.Framework;

namespace Brents6502Tests.Assembling.Tokens
{
    [TestFixture]
    public class TokenMatchReplacementTests : TokenReplacementTest
    {
        protected override ITokenReplacement Replacer => new TokenMatchReplacement();

        [Test]
        public void Match_should_be_found()
        {
            ShouldFind("hat_Zest", "hat_Zest", "$01FA", "$01FA");
            ShouldFind("hatzest", "hatzest", "$01FA", "$01FA");
            ShouldFind("HatZest", "HatZest", "$01FA", "$01FA");
        }

        [Test]
        public void Match_should_not_be_found()
        {
            ShouldNotFind("hat_Zest", "Hat_Zest", "$01FA");
            ShouldNotFind("hatzest", "hatZest", "$01FA");
            ShouldNotFind("HatZest", "hatZest", "$01FA");
        }
    }
}
