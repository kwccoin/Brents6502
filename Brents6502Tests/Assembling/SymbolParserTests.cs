using Brents6502.Assembling;
using NUnit.Framework;

namespace Brents6502Tests.Assembling
{
    [TestFixture]
    public class SymbolParserTests
    {
        [Test]
        public void Symbols_should_not_have_arguments()
        {
            string lineSrc = "DEX";
            SymbolParser parser = new SymbolParser();
            Line line = parser.ParseAssemblyLine(lineSrc, 1);
            Assert.AreEqual(1, line.Instruction.LineNumber);
            Assert.AreEqual("DEX", line.Instruction.Source);
            Assert.AreEqual(0, line.Arguments.Length);
        }

        [Test]
        public void Symbols_should_have_single_argument()
        {
            string lineSrc = "LDA $9F";
            SymbolParser parser = new SymbolParser();
            Line line = parser.ParseAssemblyLine(lineSrc, 1);
            Assert.AreEqual(1, line.Instruction.LineNumber);
            Assert.AreEqual("LDA", line.Instruction.Source);
            Assert.AreEqual(1, line.Arguments.Length);
            Assert.AreEqual(1, line.Arguments[0].LineNumber);
            Assert.AreEqual("$9F", line.Arguments[0].Source);
        }

        [Test]
        public void Indirect_should_have_single_argument()
        {
            string lineSrc = "LDA ($9F),X";
            SymbolParser parser = new SymbolParser();
            Line line = parser.ParseAssemblyLine(lineSrc, 1);
            Assert.AreEqual(1, line.Instruction.LineNumber);
            Assert.AreEqual("LDA", line.Instruction.Source);
            Assert.AreEqual(1, line.Arguments.Length);
            Assert.AreEqual(1, line.Arguments[0].LineNumber);
            Assert.AreEqual("($9F),X", line.Arguments[0].Source);
        }

        [Test]
        public void Absolute_should_have_single_argument()
        {
            string lineSrc = "LDA ($9FA3,X)";
            SymbolParser parser = new SymbolParser();
            Line line = parser.ParseAssemblyLine(lineSrc, 1);
            Assert.AreEqual(1, line.Instruction.LineNumber);
            Assert.AreEqual("LDA", line.Instruction.Source);
            Assert.AreEqual(1, line.Arguments.Length);
            Assert.AreEqual(1, line.Arguments[0].LineNumber);
            Assert.AreEqual("($9FA3,X)", line.Arguments[0].Source);
        }

        [Test]
        public void MultiArgNoCommas_should_have_many_arguments()
        {
            string lineSrc = "DCB $9F $34 $FA";
            SymbolParser parser = new SymbolParser();
            Line line = parser.ParseAssemblyLine(lineSrc, 1);
            Assert.AreEqual(1, line.Instruction.LineNumber);
            Assert.AreEqual("DCB", line.Instruction.Source);
            Assert.AreEqual(3, line.Arguments.Length);
            Assert.AreEqual(1, line.Arguments[0].LineNumber);
            Assert.AreEqual(1, line.Arguments[1].LineNumber);
            Assert.AreEqual(1, line.Arguments[2].LineNumber);
            Assert.AreEqual("$9F", line.Arguments[0].Source);
            Assert.AreEqual("$34", line.Arguments[1].Source);
            Assert.AreEqual("$FA", line.Arguments[2].Source);
        }

        [Test]
        public void MultiArgCommas_should_have_many_arguments()
        {
            string lineSrc = "DCB $9F,$34,$FA";
            SymbolParser parser = new SymbolParser();
            Line line = parser.ParseAssemblyLine(lineSrc, 1);
            Assert.AreEqual(1, line.Instruction.LineNumber);
            Assert.AreEqual("DCB", line.Instruction.Source);
            Assert.AreEqual(3, line.Arguments.Length);
            Assert.AreEqual(1, line.Arguments[0].LineNumber);
            Assert.AreEqual(1, line.Arguments[1].LineNumber);
            Assert.AreEqual(1, line.Arguments[2].LineNumber);
            Assert.AreEqual("$9F", line.Arguments[0].Source);
            Assert.AreEqual("$34", line.Arguments[1].Source);
            Assert.AreEqual("$FA", line.Arguments[2].Source);
        }
    }
}
