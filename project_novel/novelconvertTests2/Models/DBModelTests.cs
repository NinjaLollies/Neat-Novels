using Microsoft.VisualStudio.TestTools.UnitTesting;
using novelconvert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace novelconvert.Models.Tests
{
    [TestClass()]
    public class DBModelTests
    {
        [TestMethod()]
        public void AddingReadingTest()
        {
            //get user id and novel id
            int userID = 14;
            int novelID = 1;

            //adding it to database
            DBModel db = new DBModel();
            bool adding_checking = db.AddingReading(userID, novelID);

            Assert.IsTrue(adding_checking);
        }

        [TestMethod()]
        public void GetNovelByUserIdTest()
        {
            //get user ID
            int userID = 14;

            //get novel by userID
            DBModel db = new DBModel();
            List<NovelModel> myNovel = db.GetNovelByUserId(userID);

            Assert.IsTrue(myNovel.Count() > 0);
        }
    }
}