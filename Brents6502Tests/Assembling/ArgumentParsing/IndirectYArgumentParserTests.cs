using Brents6502.Assembling.ArgumentParsing;
using NUnit.Framework;

namespace Brents6502Tests.Assembling.ArgumentParsing
{
    [TestFixture]
    public class IndirectYArgumentParserTests : ArgumentParserTests
    {
        [Test]
        public void Address_should_be_parseable()
        {
            IArgumentParser parser = new IndirectYArgumentParser();
            ShouldHandle("($00),Y", parser);
            ShouldHandle("($01),Y", parser);
            ShouldHandle("($10),Y", parser);
            ShouldHandle("($F0),Y", parser);
            ShouldHandle("($FF),Y", parser);
            ShouldHandle("($FA),Y", parser);
        }

        [Test]
        public void Address_should_not_be_parseable()
        {
            IArgumentParser parser = new IndirectYArgumentParser();
            ShouldNotHandle("#0", parser);
            ShouldNotHandle("#$10", parser);
            ShouldNotHandle("$F4", parser);
            ShouldNotHandle("$F035", parser);
            ShouldNotHandle("$F035,X", parser);
            ShouldNotHandle("$F035,Y", parser);
        }

        [Test]
        public void ParsedAddress_should_be_equal()
        {
            IArgumentParser parser = new IndirectYArgumentParser();
            var a = GetBytes("($00),Y", parser);
            var b = GetBytes("($01),Y", parser);
            var c = GetBytes("($10),Y", parser);
            var d = GetBytes("($F0),Y", parser);
            var e = GetBytes("($FF),Y", parser);
            var f = GetBytes("($FA),Y", parser);
            Assert.AreEqual(1, a.Length);
            Assert.AreEqual(1, b.Length);
            Assert.AreEqual(1, c.Length);
            Assert.AreEqual(1, d.Length);
            Assert.AreEqual(1, e.Length);
            Assert.AreEqual(1, f.Length);
            Assert.AreEqual(0x00, a[0]);
            Assert.AreEqual(0x01, b[0]);
            Assert.AreEqual(0x10, c[0]);
            Assert.AreEqual(0xF0, d[0]);
            Assert.AreEqual(0xFF, e[0]);
            Assert.AreEqual(0xFA, f[0]);
        }
    }
}
