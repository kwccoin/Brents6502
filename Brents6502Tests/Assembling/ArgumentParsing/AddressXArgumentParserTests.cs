using Brents6502.Assembling.ArgumentParsing;
using NUnit.Framework;

namespace Brents6502Tests.Assembling.ArgumentParsing
{
    [TestFixture]
    public class AddressXArgumentParserTests : ArgumentParserTests
    {
        [Test]
        public void Address_should_be_parseable()
        {
            IArgumentParser parser = new AddressXArgumentParser();
            ShouldHandle("$0000,X", parser);
            ShouldHandle("$0135,X", parser);
            ShouldHandle("$1035,X", parser);
            ShouldHandle("$F035,X", parser);
            ShouldHandle("$FFFF,X", parser);
            ShouldHandle("$FA3D,X", parser);
        }

        [Test]
        public void Address_should_not_be_parseable()
        {
            IArgumentParser parser = new AddressXArgumentParser();
            ShouldNotHandle("#0", parser);
            ShouldNotHandle("#$10", parser);
            ShouldNotHandle("$F4", parser);
            ShouldNotHandle("($F035)", parser);
            ShouldNotHandle("($3F),X", parser);
            ShouldNotHandle("($3F),Y", parser);
        }

        [Test]
        public void ParsedAddress_should_be_equal()
        {
            IArgumentParser parser = new AddressXArgumentParser();
            var a = GetBytes("$0000,X", parser);
            var b = GetBytes("$0135,X", parser);
            var c = GetBytes("$1035,X", parser);
            var d = GetBytes("$F035,X", parser);
            var e = GetBytes("$FFFF,X", parser);
            var f = GetBytes("$FA3D,X", parser);
            Assert.AreEqual(2, a.Length);
            Assert.AreEqual(2, b.Length);
            Assert.AreEqual(2, c.Length);
            Assert.AreEqual(2, d.Length);
            Assert.AreEqual(2, e.Length);
            Assert.AreEqual(2, f.Length);
            Assert.AreEqual(0x00, a[0]);
            Assert.AreEqual(0x00, a[1]);
            Assert.AreEqual(0x35, b[0]);
            Assert.AreEqual(0x01, b[1]);
            Assert.AreEqual(0x35, c[0]);
            Assert.AreEqual(0x10, c[1]);
            Assert.AreEqual(0x35, d[0]);
            Assert.AreEqual(0xF0, d[1]);
            Assert.AreEqual(0xFF, e[0]);
            Assert.AreEqual(0xFF, e[1]);
            Assert.AreEqual(0x3D, f[0]);
            Assert.AreEqual(0xFA, f[1]);
        }
    }
}
