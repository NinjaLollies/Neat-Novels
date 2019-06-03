using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core21.Models;

namespace core21.NunitTest
{
    [TestFixture]
    public class AccountTest
    {
        //Test method ensures that a email and username are inputted
        //and properly handled when the register button is clicked
        [TestCase]
        public void RegisterTest()
        {
            UserDBModel db = new UserDBModel();
            //Model that contains user details
            string email = "2a@live.com";
            string password = "abcd1234";

            UserModel um = db.UserRegister(email, password);

            Assert.AreEqual(um.fUsername, email);
            Assert.AreEqual(um.fPassword, password);
        }

        [TestCase]
        public void LoginTest()
        {
            UserDBModel db = new UserDBModel();

            string email = "TheVinh";
            string password = "123";

            UserModel um = db.UserLogin(email, password);

            Assert.AreEqual(um.fUsername, email);
            Assert.AreEqual(um.fPassword, password);
        }

        [TestCase]
        public void CheckingExistUser()
        {
            UserDBModel db = new UserDBModel();

            string username = "a@live.com";

            bool um = db.UserNameExistChecking(username);

            Assert.IsTrue(um); //false mean does not exist, true mean user exist
        }

        [TestCase]
        public void RemoveUser()
        {
            UserDBModel db = new UserDBModel();

            string userid = "1";

            string adminUsername = "tony@gmail";
            string adminPass = "123";

            bool isAdmin = db.AdminChecking(adminUsername, adminPass);
            bool removeUser = false;

            if (isAdmin)
            {
                removeUser = db.RemoveUserById(userid);
            }

            Assert.IsTrue(isAdmin);
            Assert.IsTrue(removeUser);
        }

        [TestCase]
        public void GetAllUser_Admin()
        {
            UserDBModel db = new UserDBModel();

            string adminUsername = "tony@gmail";
            string adminPass = "123";

            bool isAdmin = db.AdminChecking(adminUsername, adminPass);
            List<UserModel> allUser = new List<UserModel>();

            if (isAdmin)
            {
                allUser = db.GetAllUser(adminUsername, adminPass);
            }

            Assert.IsTrue(isAdmin);
            Assert.IsTrue(allUser.Count() > 1);
        }
    }
}
