using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using novelconvert.Models;
using System.Web.Mvc;

namespace novelconvert.Controllers
{
    public class ReadingController: Controller
    {
        public ActionResult Index(string id, string chapter)
        {
            ViewBag.BookID = id;

            if(chapter == null)
            {
                chapter = "1";
            }
            ViewBag.Chapter = chapter;
            ViewBag.NextChapter = Int32.Parse(chapter) + 1;
            ViewBag.Previous = (Int32.Parse(chapter) > 1) ? Int32.Parse(chapter) - 1 : Int32.Parse(chapter);

            DBModel db = new DBModel();
            NovelModel nv = db.SelectOneNovel(id);
            return View(nv);
        }
    }
}
