using System;
using KillerApp_Library.Controllers;
using KillerApp_Library.Domain_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KillerApp_UnitTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void LoginTest()
        {
            bool user = UserController.GetInstance().Login("admin", "admin");

            Assert.AreEqual(user, true);
        }

        [TestMethod]
        public void AddNewUserTest()
        {
            bool registeredUser = UserController.GetInstance().Register("super", "admin", "admin@hotmail.com");

            Assert.AreEqual(registeredUser, true);
        }

        [TestMethod]
        public void DeclineNewUserTest()
        {
            bool registeredUser = UserController.GetInstance().Register("admin", "admin", "admin@hotmail.com");

            Assert.AreEqual(registeredUser, false);
        }

        [TestMethod]
        public void RemoveExistingUser()
        {
            bool removingUser = UserController.GetInstance().Remove(1);

            Assert.AreEqual(removingUser, false);
        }

        [TestMethod]
        public void LogoutUserTest()
        {
            bool logingOutUser = UserController.GetInstance().Logout(0);

            Assert.AreEqual(logingOutUser, false);
        }
    }
}
