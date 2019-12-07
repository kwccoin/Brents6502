using Brents6502.Assembling.ArgumentParsing;
using NUnit.Framework;

namespace Brents6502Tests.Assembling.ArgumentParsing
{
    [TestFixture]
    public class IndirectXArgumentParserTests : ArgumentParserTests
    {
        [Test]
        public void Address_should_be_parseable()
        {
            IArgumentParser parser = new IndirectXArgumentParser();
            ShouldHandle("($00,X)", parser);
            ShouldHandle("($01,X)", parser);
            ShouldHandle("($10,X)", parser);
            ShouldHandle("($F0,X)", parser);
            ShouldHandle("($FF,X)", parser);
            ShouldHandle("($FA,X)", parser);
        }

        [Test]
        public void Address_should_not_be_parseable()
        {
            IArgumentParser parser = new IndirectXArgumentParser();
            ShouldNotHandle("#0", parser);
            ShouldNotHandle("#$10", parser);
            ShouldNotHandle("$F4", parser);
            ShouldNotHandle("$F035", parser);
            ShouldNotHandle("$F035,X", parser);
            ShouldNotHandle("$F035,Y", parser);
            ShouldNotHandle("($3F),Y", parser);
        }

        [Test]
        public void ParsedAddress_should_be_equal()
        {
            IArgumentParser parser = new IndirectXArgumentParser();
            var a = GetBytes("($00,X)", parser);
            var b = GetBytes("($01,X)", parser);
            var c = GetBytes("($10,X)", parser);
            var d = GetBytes("($F0,X)", parser);
            var e = GetBytes("($FF,X)", parser);
            var f = GetBytes("($FA,X)", parser);
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
