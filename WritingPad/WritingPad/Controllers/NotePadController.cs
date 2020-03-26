using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WritingPad.Controllers
{
    public class NotePadController : Controller
    {
        WritingPadEntities db;
        // GET: NotePad
        public NotePadController()
        {
            db = new WritingPadEntities();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Insert()
        {
            if (Session["LoginUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult Insert(string title,string explanation,string noteUrl,HttpPostedFileBase uploadFile)
        {
            if(Session["LoginUser"] != null)
            {
                AppUser appUser = (AppUser)Session["LoginUser"];

                string fileName = string.Empty; 

                if (uploadFile.FileName != null)
                {
                    uploadFile.SaveAs(Server.MapPath("~/Uploads/") + uploadFile.FileName);
                    fileName = uploadFile.FileName;
                }

                NotePad notePad = new NotePad()
                {
                    Title= title,
                    Explanation=explanation,
                    NoteUrl= noteUrl,
                    AppUserId=appUser.AppUserId,
                    FilePath=fileName
                };

                db.NotePad.Add(notePad);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "NotePad");
        }



    }
}