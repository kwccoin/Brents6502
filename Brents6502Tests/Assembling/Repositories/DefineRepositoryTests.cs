using Brents6502.Assembling.Repositories;
using NUnit.Framework;

namespace Brents6502Tests.Assembling.Repositories
{
    [TestFixture]
    public class DefineRepositoryTests
    {
        [Test]
        public void AddedDefine_should_be_found()
        {
            string key = "Test", value = "$9F";
            DefineRepository repo = new DefineRepository();
            repo.AddDefine(key, "$9F");
            bool found = repo.TryGetValue(key, out var res);
            Assert.IsTrue(found);
            Assert.AreEqual(value, res);
        }

        [Test]
        public void AddedDefine_not_adding_should_not_be_found()
        {
            DefineRepository repo = new DefineRepository();
            bool found = repo.TryGetValue("Test", out var res);
            Assert.IsFalse(found);
            Assert.IsTrue(string.IsNullOrEmpty(res));
        }
    }
}
