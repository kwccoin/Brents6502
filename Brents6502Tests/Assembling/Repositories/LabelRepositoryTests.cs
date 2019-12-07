using Brents6502.Assembling.Repositories;
using NUnit.Framework;

namespace Brents6502Tests.Assembling.Repositories
{
    [TestFixture]
    public class LabelRepositoryTests
    {
        [Test]
        public void AddedLabel_should_be_found()
        {
            string key = "Test";
            ushort addr = 0x9F;
            LabelRepository repo = new LabelRepository();
            repo.CreateLabel(key);
            repo.SetAddress(key, addr);
            bool found = repo.TryGetValue(key, out var res);
            Assert.IsTrue(found);
            Assert.AreEqual(addr, res);
        }

        [Test]
        public void AddedLabel_not_adding_should_not_be_found()
        {
            LabelRepository repo = new LabelRepository();
            bool found = repo.TryGetValue("Test", out var res);
            Assert.IsFalse(found);
            Assert.AreEqual(0, res);
        }

        [Test]
        public void AddedLabel_not_setting_addr_and_getting_should_throw()
        {
            string key = "Test";
            ushort addr = 0x9F;
            LabelRepository repo = new LabelRepository();
            repo.CreateLabel(key);
            Assert.Throws<LabelAddressNotAssignedException>(() => repo.TryGetValue(key, out ushort res));
        }
    }
}
