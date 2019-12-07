using Brents6502.Assembling;
using Brents6502.Assembling.ArgumentParsing;
using FakeItEasy;
using NUnit.Framework;

namespace Brents6502Tests.Assembling.ArgumentParsing
{
    public class ArgumentParserTests
    {
        protected void ShouldHandle(string value, IArgumentParser parser)
        {
            var symbol = A.Fake<IArgumentSymbol>();
            A.CallTo(() => symbol.Source).Returns(value);
            Assert.IsTrue(parser.ShouldHandle(symbol));
        }

        protected void ShouldNotHandle(string value, IArgumentParser parser)
        {
            var symbol = A.Fake<IArgumentSymbol>();
            A.CallTo(() => symbol.Source).Returns(value);
            Assert.IsFalse(parser.ShouldHandle(symbol));
        }

        protected byte[] GetBytes(string value, IArgumentParser parser)
        {
            var symbol = A.Fake<IArgumentSymbol>();
            A.CallTo(() => symbol.Source).Returns(value);
            return parser.GetBytes(symbol);
        }
    }
}
