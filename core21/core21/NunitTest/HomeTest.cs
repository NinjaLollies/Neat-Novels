﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core21.Models;

namespace core21.NunitTest
{
    [TestFixture]
    public class HomeTest
    {
        [TestCase]
        public void GetAllNovel()
        {
            DBModel db = new DBModel();
            List<NovelModel> listNovel = db.AllNovel();

            Assert.IsTrue(listNovel.Count() != 0);
        }

        [TestCase]
        public void GetNovelById()
        {
            string id = "1";

            DBModel db = new DBModel();
            NovelModel novel = db.SelectOneNovel(id);

            Assert.AreEqual(novel.Id, id);
        }

        [TestCase]
        public void AddingNovel()
        {
            NovelModel nv = new NovelModel();
            nv.Name = "new novel";
            nv.Link = "2.txt";
            nv.Image_link = "#";
            nv.Author = "Tony";
            nv.Chap_number = 1;
            nv.Owner = "14";
            nv.upload_date = DateTime.Now;

            DBModel db = new DBModel();
            bool novel = db.AddNewNovel(nv);

            Assert.IsTrue(novel); //check that add new novel is success or not
        }

        //[TestCase]
        //public void RemoveBook()
        //{
        //    string id = "11";

        //    DBModel db = new DBModel();
        //    bool novel = db.RemoveNovelById(id);

        //    Assert.IsTrue(novel); //check that add new novel is success or not
        //}

        [TestCase]
        public void EditNovelInfor()
        {
            DBModel db = new DBModel();
            //get novel by id
            NovelModel nv = db.SelectOneNovel("1");
            //new infor, cannot change id
            NovelModel newNv = new NovelModel();
            newNv = nv;
            newNv.Name = "Hello";
            newNv.Author = "Fire";

            bool novel = db.EditNovel(Int32.Parse(nv.Id), newNv);

            Assert.IsTrue(novel); //check that add new novel is success or not
        }
    }
}
