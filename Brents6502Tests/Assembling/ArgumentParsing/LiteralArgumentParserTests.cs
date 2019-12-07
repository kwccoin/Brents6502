using Brents6502.Assembling.ArgumentParsing;
using NUnit.Framework;

namespace Brents6502Tests.Assembling.ArgumentParsing
{
    [TestFixture]
    public class LiteralArgumentParserTests : ArgumentParserTests
    {
        // TODO:  Need to write tests for exceptions

        [Test]
        public void Address_should_be_parseable()
        {
            IArgumentParser parser = new LiteralArgumentParser();
            ShouldHandle("#9", parser);
            ShouldHandle("#255", parser);
            ShouldHandle("#58", parser);
            ShouldHandle("#$08", parser);
            ShouldHandle("#$F8", parser);
            ShouldHandle("#$FD", parser);
        }

        [Test]
        public void Address_should_not_be_parseable()
        {
            IArgumentParser parser = new LiteralArgumentParser();
            ShouldNotHandle("#-5", parser);
            ShouldNotHandle("#8268", parser);
            ShouldNotHandle("$F4", parser);
            ShouldNotHandle("$F035", parser);
            ShouldNotHandle("$F035,X", parser);
            ShouldNotHandle("$F035,Y", parser);
            ShouldNotHandle("($3F),Y", parser);
        }

        [Test]
        public void ParsedAddress_should_be_equal()
        {
            IArgumentParser parser = new LiteralArgumentParser();
            var a = GetBytes("#9", parser);
            var b = GetBytes("#255", parser);
            var c = GetBytes("#58", parser);
            var d = GetBytes("#$08", parser);
            var e = GetBytes("#$F8", parser);
            var f = GetBytes("#$FD", parser);
            Assert.AreEqual(1, a.Length);
            Assert.AreEqual(1, b.Length);
            Assert.AreEqual(1, c.Length);
            Assert.AreEqual(1, d.Length);
            Assert.AreEqual(1, e.Length);
            Assert.AreEqual(1, f.Length);
            Assert.AreEqual(9, a[0]);
            Assert.AreEqual(255, b[0]);
            Assert.AreEqual(58, c[0]);
            Assert.AreEqual(0x08, d[0]);
            Assert.AreEqual(0xF8, e[0]);
            Assert.AreEqual(0xFD, f[0]);
        }
    }
}
