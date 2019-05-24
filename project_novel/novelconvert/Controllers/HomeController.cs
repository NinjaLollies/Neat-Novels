using System.Collections.Generic;
using System.Web.Mvc;
using novelconvert.Models;
using MySql.Data;
using System;

namespace novelconvert.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int id = 0)
        {
            DBModel db = new DBModel();
            
            List<NovelModel> nv = db.TenNovel();

            string userID = Request.Cookies["userID"].Value.ToString();
            List<NovelModel> userNovel = db.GetNovelByUserId(Int32.Parse(userID));

            ViewBag.UserNovel = userNovel;

            return View(nv);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}