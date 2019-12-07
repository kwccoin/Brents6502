using Brents6502.Assembling.Tokens;
using NUnit.Framework;

namespace Brents6502Tests.Assembling.Tokens
{
    [TestFixture]
    public class TokenAbsoluteReplacementTests : TokenReplacementTest
    {
        protected override ITokenReplacement Replacer => new TokenAbsoluteReplacement();

        [Test]
        public void Match_should_be_found()
        {
            ShouldFind("(hat_Zest,X)", "hat_Zest", "$01FA", "($01FA,X)");
            ShouldFind("(hatzest,X)", "hatzest", "$01FA", "($01FA,X)");
            ShouldFind("(HatZest,X)", "HatZest", "$01FA", "($01FA,X)");
            ShouldFind("(hat_Zest,x)", "hat_Zest", "$01FA", "($01FA,x)");
            ShouldFind("(hatzest,x)", "hatzest", "$01FA", "($01FA,x)");
            ShouldFind("(HatZest,x)", "HatZest", "$01FA", "($01FA,x)");
            ShouldFind("(hat_Zest,Y)", "hat_Zest", "$01FA", "($01FA,Y)");
            ShouldFind("(hatzest,Y)", "hatzest", "$01FA", "($01FA,Y)");
            ShouldFind("(HatZest,Y)", "HatZest", "$01FA", "($01FA,Y)");
            ShouldFind("(hat_Zest,y)", "hat_Zest", "$01FA", "($01FA,y)");
            ShouldFind("(hatzest,y)", "hatzest", "$01FA", "($01FA,y)");
            ShouldFind("(HatZest,y)", "HatZest", "$01FA", "($01FA,y)");
        }

        [Test]
        public void Match_should_not_be_found()
        {
            ShouldNotFind("(hat_Zest,X)", "Hat_Zest", "$01FA");
            ShouldNotFind("(hatzest,X)", "hatZest", "$01FA");
            ShouldNotFind("(HatZest,X)", "hatZest", "$01FA");
            ShouldNotFind("(hat_Zest,x)", "Hat_Zest", "$01FA");
            ShouldNotFind("(hatzest,x)", "hatZest", "$01FA");
            ShouldNotFind("(HatZest,x)", "hatZest", "$01FA");
            ShouldNotFind("(hat_Zest,Y)", "Hat_Zest", "$01FA");
            ShouldNotFind("(hatzest,Y)", "hatZest", "$01FA");
            ShouldNotFind("(HatZest,Y)", "hatZest", "$01FA");
            ShouldNotFind("(hat_Zest,y)", "Hat_Zest", "$01FA");
            ShouldNotFind("(hatzest,y)", "hatZest", "$01FA");
            ShouldNotFind("(HatZest,y)", "hatZest", "$01FA");
        }
    }
}
