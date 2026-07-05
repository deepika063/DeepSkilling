using NUnit.Framework;
using UserManagerLib;
using System;

namespace UserManagerLib.Tests
{
    [TestFixture]
    public class UserManagerTests
    {
        private UserManager manager;

        [SetUp]
        public void SetUp()
        {
            manager = new UserManager();
        }

        // Happy Path
        [Test]
        public void CreateUser_ValidPAN_ReturnsTrue()
        {
            User user = new User();
            user.PANCardNo = "ABCDE1234F";

            bool result = manager.CreateUser(user);

            Assert.That(result, Is.True);
        }

        // Null PAN
        [Test]
        public void CreateUser_NullPAN_ThrowsNullReferenceException()
        {
            User user = new User();
            user.PANCardNo = null;

            Assert.Throws<NullReferenceException>(() =>
                manager.CreateUser(user));
        }

        // Empty PAN
        [Test]
        public void CreateUser_EmptyPAN_ThrowsNullReferenceException()
        {
            User user = new User();
            user.PANCardNo = "";

            Assert.Throws<NullReferenceException>(() =>
                manager.CreateUser(user));
        }

        // Invalid PAN Length
        [TestCase("ABCDE123")]
        [TestCase("ABCDE123456")]
        [TestCase("ABC")]
        [TestCase("123456789")]
        public void CreateUser_InvalidPANLength_ThrowsFormatException(string pan)
        {
            User user = new User();
            user.PANCardNo = pan;

            Assert.Throws<FormatException>(() =>
                manager.CreateUser(user));
        }
    }
}
