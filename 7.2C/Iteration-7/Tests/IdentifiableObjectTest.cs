using NUnit.Framework;
using Swin_Adventure;

namespace Tests
{
    [TestFixture]
    public class IdentifiableObjectTest
    {

        [Test]
        public void TestAreYou()
        {
            string[] testStringArray = new string[] { "Test", "CheckOrder" };
            IdentifiableObject testObject = new IdentifiableObject(testStringArray);
            Assert.IsTrue(testObject.AreYou("CheckOrder"));
        }

        [Test]
        public void TestNotAreYou()
        {
            string[] testStringArray = new string[] { "Test", "CheckOrder" };
            IdentifiableObject testObject = new IdentifiableObject(testStringArray);
            Assert.IsFalse(testObject.AreYou("wilma"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            string[] testStringArray = new string[] { "Test", "CheckOrder" };
            IdentifiableObject testObject = new IdentifiableObject(testStringArray);
            Assert.IsTrue(testObject.AreYou("test"));
        }

        [Test]
        public void TestFirstID()
        {
            string[] testStringArray = new string[] { "Test", "CheckOrder" };
            IdentifiableObject testObject = new IdentifiableObject(testStringArray);
            StringAssert.AreEqualIgnoringCase("Test", testObject.FirstID);
        }

        [Test]
        public void TestAddID()
        {
            string[] testStringArray = new string[] { "Fred", "Bob" };
            IdentifiableObject testObject = new IdentifiableObject(testStringArray);
            testObject.AddIdentifier("wilma");
            Assert.IsTrue(testObject.AreYou("Fred"));
            Assert.IsTrue(testObject.AreYou("bob"));
            Assert.IsTrue(testObject.AreYou("wilma"));
        }
    }
}