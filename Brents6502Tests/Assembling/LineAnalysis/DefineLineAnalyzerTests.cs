using Brents6502.Assembling.LineAnalysis;
using Brents6502.Assembling.Repositories;
using FakeItEasy;
using NUnit.Framework;

namespace Brents6502Tests.Assembling.LineAnalysis
{
    [TestFixture]
    public class DefineLineAnalyzerTests
    {
        [Test]
        public void String_should_be_define()
        {
            DefineLineAnalyzer analyzer = new DefineLineAnalyzer(A.Fake<IDefineRepository>());
            Assert.IsTrue(analyzer.ShouldHandle("define myVar $3F"));
            Assert.IsTrue(analyzer.ShouldHandle("define myVar 3"));
            Assert.IsTrue(analyzer.ShouldHandle("define myVar 24"));
            Assert.IsTrue(analyzer.ShouldHandle("define myVar $22"));
            Assert.IsTrue(analyzer.ShouldHandle("define myVar $FA"));
        }

        [Test]
        public void String_should_not_be_define()
        {
            DefineLineAnalyzer analyzer = new DefineLineAnalyzer(A.Fake<IDefineRepository>());
            Assert.IsFalse(analyzer.ShouldHandle("LDA $4F"));
            Assert.IsFalse(analyzer.ShouldHandle("DEX"));
            Assert.IsFalse(analyzer.ShouldHandle("DCB $44 $36 $F3"));
            Assert.IsFalse(analyzer.ShouldHandle("LDA ($22),X"));
            Assert.IsFalse(analyzer.ShouldHandle("LDA ($F2D2,X)"));
        }

        [Test]
        public void AddingDefineLine_should_add_to_repository()
        {
            var repo = A.Fake<IDefineRepository>();
            DefineLineAnalyzer analyzer = new DefineLineAnalyzer(repo);
            analyzer.HandleLine("define myVar $3F");
            A.CallTo(() => repo.AddDefine(A<string>.That.IsEqualTo("myVar"), A<string>.That.IsEqualTo("$3F")))
                .MustHaveHappenedOnceExactly();
        }
    }
}
