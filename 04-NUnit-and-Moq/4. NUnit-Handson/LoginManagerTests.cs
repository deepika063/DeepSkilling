using NUnit.Framework;
using AccountsManagerLib;
using System;

namespace AccountsManagerLib.Tests
{
    [TestFixture]
    public class LoginManagerTests
    {
        private LoginManager loginManager;

        [SetUp]
        public void SetUp()
        {
            loginManager = new LoginManager();
        }

        [Test]
        public void Login_ValidUser11_ReturnsWelcomeMessage()
        {
            string actual = loginManager.Login("user_11", "secret@user11");

            Assert.That(actual, Is.EqualTo("Welcome user_11!!!"));
        }

        [Test]
        public void Login_ValidUser22_ReturnsWelcomeMessage()
        {
            string actual = loginManager.Login("user_22", "secret@user22");

            Assert.That(actual, Is.EqualTo("Welcome user_22!!!"));
        }

        [Test]
        public void Login_InvalidCredentials_ReturnsInvalidMessage()
        {
            string actual = loginManager.Login("user_11", "wrongpassword");

            Assert.That(actual, Is.EqualTo("Invalid user id/password"));
        }

        [Test]
        public void Login_EmptyUserId_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                loginManager.Login("", "secret@user11"));
        }

        [Test]
        public void Login_EmptyPassword_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                loginManager.Login("user_11", ""));
        }

        [Test]
        public void Login_BothEmpty_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                loginManager.Login("", ""));
        }
    }
}
