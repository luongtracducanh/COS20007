using NUnit.Framework;
using Swin_Adventure;

namespace Tests
{
    [TestFixture]
    public class ItemTest
    {
        new Item i = new Item(new string[] { "potion" }, "red", "A bitter-smelling red potion");

        [Test]
        public void TestItemIsIdentifiable()
        {
            bool actual = i.AreYou("potion");

            Assert.IsTrue(actual, "Test Item AreYou a Potion");
        }

        [Test]
        public void TestItemShortDesc()
        {
            string actual = i.ShortDescription;
            string expected = "a red potion";

            Assert.AreEqual(actual, expected, "Test Item ShortDesc");
        }

        [Test]
        public void TestItemFullDescription()
        {
            string actual = i.LongDescription;
            string expected = "A bitter-smelling red potion";

            Assert.AreEqual(actual, expected, "Itest Item LongDesc");
        }

    }
}
