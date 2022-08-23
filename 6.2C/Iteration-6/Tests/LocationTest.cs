using NUnit.Framework;
using Swin_Adventure;

namespace Tests
{
    [TestFixture]
    public class LocationTest
    {
        Location l;
        Player p;

        [Test]
        public void TestPlayerCanLocateLocation()
        {
            p = new Player("Tohru", "O No Not More References Y U Do Dis");
            l = new Location("Classroom", "A classroom with a few rows of long tables. Each table seems to contain five pieces of junk known as iMacs. ");
            p.Location = l;

            bool actual = l.AreYou("location");

            Assert.IsTrue(actual, "Test Location can identify itself as 'location'");
        }

        [Test]
        public void TestPlayerHasLocation()
        {
            p = new Player("Miki Sano", "Admiral of the Kotona Choir");
            l = new Location("Classroom", "A classroom with a long rows of tables. Each table seems to contain " +
                "pieces of junk known as iMacs. ");

            p.Location = l;

            GameObject expected = l;
            GameObject actual = p.Locate("room");

            Assert.AreEqual(expected, actual, "Test if the player can locate their location using the Locate Command");
        }

        [Test]
        public void TestLocationIdentifyItems()
        {
            l = new Location("Classroom", "A classroom with a long rows of tables. Each table seems to contain " +
                "pieces of junk known as iMacs. ");
            Item i = new Item(new string[] { "potion" }, "red", "A bitter-smelling red potion");
            l.Inventory.Put(i);

            GameObject expected = i;
            GameObject actual = l.Locate("potion");

            Assert.AreEqual(expected, actual, "Test Location can identify itself as 'location'");
        }
    }
}
