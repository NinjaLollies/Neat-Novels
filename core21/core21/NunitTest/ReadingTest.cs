using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core21.Models;

namespace core21.NunitTest
{
    [TestFixture]
    public class ReadingTest
    {
        [TestCase]
        public void VotingTest()
        {
            //get novel by id
            DBModel db = new DBModel();
            NovelModel nv = db.SelectOneNovel("1");
            int old_view = nv.Viewer;
            //increasing view
            nv.Viewer += 1;
            bool viewChecking = db.EditNovel(Int32.Parse("1"), nv);

            Assert.IsTrue(nv.Viewer > old_view);
        }
    }
}
