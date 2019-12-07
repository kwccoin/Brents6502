using Brents6502.Assembling.LineAnalysis;
using Brents6502.Assembling.Repositories;
using FakeItEasy;
using NUnit.Framework;

namespace Brents6502Tests.Assembling.LineAnalysis
{
    [TestFixture]
    public class LabelLineAnalyzerTests
    {

        [Test]
        public void String_should_be_label()
        {
            LabelLineAnalyzer analyzer = new LabelLineAnalyzer(A.Fake<ILabelRepository>());
            Assert.IsTrue(analyzer.ShouldHandle("label:"));
            Assert.IsTrue(analyzer.ShouldHandle("lblHere:"));
            Assert.IsTrue(analyzer.ShouldHandle("label_goesHere:"));
            Assert.IsTrue(analyzer.ShouldHandle("name8_can_Work:"));
        }

        [Test]
        public void String_should_not_be_define()
        {
            LabelLineAnalyzer analyzer = new LabelLineAnalyzer(A.Fake<ILabelRepository>());
            Assert.IsFalse(analyzer.ShouldHandle("LDA $4F"));
            Assert.IsFalse(analyzer.ShouldHandle("DEX"));
            Assert.IsFalse(analyzer.ShouldHandle("DCB $44 $36 $F3"));
            Assert.IsFalse(analyzer.ShouldHandle("LDA ($22),X"));
            Assert.IsFalse(analyzer.ShouldHandle("define"));
        }

        [Test]
        public void AddingDefineLine_should_add_to_repository()
        {
            var repo = A.Fake<ILabelRepository>();
            LabelLineAnalyzer analyzer = new LabelLineAnalyzer(repo);
            analyzer.HandleLine("name8_can_Work:");
            A.CallTo(() => repo.CreateLabel(A<string>.That.IsEqualTo("name8_can_Work")))
                .MustHaveHappenedOnceExactly();
        }
    }
}
