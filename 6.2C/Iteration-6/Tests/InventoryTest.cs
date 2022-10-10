using NUnit.Framework;
using Swin_Adventure;

namespace Tests
{
    [TestFixture]
    class TestInventory
    {
        Item itm = new Item(new string[] { "potion" }, "red", "A bitter-smelling red potion");
        Item itm2 = new Item(new string[] { "potion" }, "blue", "A sour-smelling blue potion");

        [Test]
        public void TestFindItem()
        {
            Inventory i = new Inventory();

            i.Put(itm);
            bool actual = i.HasItem(itm.FirstID);

            Assert.IsTrue(actual, "Test Inventory has Item by FirstID");
        }

        [Test]
        public void TestNotFindItem()
        {
            Inventory i = new Inventory();

            i.Put(itm);
            bool actual = i.HasItem("pen");

            Assert.IsFalse(actual, "Test Inventory does not have item by FirstID");
        }

        [Test]
        public void TestFetchItem()
        {
            Inventory i = new Inventory();

            i.Put(itm);
            Item takenItem = i.Fetch(itm.FirstID);

            Assert.AreEqual(takenItem, itm, "Test Inventory Fetch such that item is not taken");
        }

        [Test]
        public void TestTakeItem()
        {
            Inventory i = new Inventory();

            i.Put(itm2);

            Item takenItem = i.Take(itm2.FirstID);

            bool actual = i.HasItem(itm2.FirstID);
            Assert.IsFalse(actual, "Test Inventory Take such that Item cannot be found by AreYou");

        }

        [Test]
        public void TestInventoryItemList()
        {
            Inventory i = new Inventory();

            i.Put(itm);
            i.Put(itm2);
            string actual = i.ItemList;
            string expected = "    a red potion\r\n    a blue potion\r\n";
            Assert.AreEqual(expected, actual, "Test Inventory List String, should be a formatted list");
        }
    }
}
