using System.Collections.Generic;
using System.Web.Mvc;
using novelconvert.Models;
using MySql.Data;

namespace novelconvert.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            UserModel user = new UserModel();

            return View(user);
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            UserDBModel db = new UserDBModel();
            UserModel luser = db.UserRegister(user.fUsername, user.fPassword);

            return RedirectToAction("../Home/Index");
        }
    }
}
