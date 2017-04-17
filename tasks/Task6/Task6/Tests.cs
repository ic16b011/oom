using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void NegativeYears()
        {
            Assert.Catch(() =>
            {
                var x = new Hobby("Test", "Test");
                x.UpdateHobbyYears(-4);
            });
        }

        [Test]
        public void EmptyName()
        {
            Assert.Catch(() =>
            {
                var x = new Hobby("", "Test");
            });
        }

        [Test]
        public void EmptyPlace()
        {
            Assert.Catch(() =>
            {
                var x = new Hobby("Test", "");
            });
        }

        [Test]
        public void NameEqualsInit()
        {
            var x = new Hobby("Test", "Test2");
            Assert.IsTrue(x.Name == "Test");
        }

        [Test]
        public void PlaceEqualsInit()
        {
            var x = new Hobby("Test", "Test2");
            Assert.IsTrue(x.Place == "Test2");
        }

        [Test]
        public void FriendplaceEqualsInit()
        {
            var x = new Friends("Test", "Test2");
            Assert.IsTrue(x.Place == "Test2");
        }

        [Test]
        public void FriendnameEqualsInit()
        {
            var x = new Friends("Test", "Test2");
            Assert.IsTrue(x.Name == "Test");
        }

        [Test]
        public void EmptyFriendPlace()
        {
            Assert.Catch(() =>
            {
                var x = new Friends("Test", "");
            });
        }

        [Test]
        public void EmptyFriendName()
        {
            Assert.Catch(() =>
            {
                var x = new Friends("", "Test");
            });
        }
    }
}
