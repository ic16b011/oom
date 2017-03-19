using System;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void negativeYears()
        {
            Assert.Catch(() =>
            {
                var x = new Hobby("Test", "Test");
                x.UpdateHobbyYears(-4);
            });
        }

        [Test]
        public void emptyName()
        {
            Assert.Catch(() =>
            {
                var x = new Hobby("", "Test");
            });
        }

        [Test]
        public void emptyPlace()
        {
            Assert.Catch(() =>
            {
                var x = new Hobby("Test", "");
            });
        }

        [Test]
        public void nameEqualsInit()
        {
            var x = new Hobby("Test", "Test2");
            Assert.IsTrue(x.Name == "Test");
        }

        [Test]
        public void placeEqualsInit()
        {
            var x = new Hobby("Test", "Test2");
            Assert.IsTrue(x.Place == "Test2");
        }

        [Test]
        public void friendplaceEqualsInit()
        {
            var x = new Friends("Test", "Test2");
            Assert.IsTrue(x.Place == "Test2");
        }

        [Test]
        public void friendnameEqualsInit()
        {
            var x = new Friends("Test", "Test2");
            Assert.IsTrue(x.Name == "Test");
        }

        [Test]
        public void emptyFriendPlace()
        {
            Assert.Catch(() =>
            {
                var x = new Friends("Test", "");
            });
        }

        [Test]
        public void emptyFriendName()
        {
            Assert.Catch(() =>
            {
                var x = new Friends("", "Test");
            });
        }
    }
}
