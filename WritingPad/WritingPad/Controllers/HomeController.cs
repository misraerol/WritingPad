using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WritingPad.Models.Insert;

namespace WritingPad.Controllers
{
    public class HomeController : Controller
    {
        WritingPadEntities db;
        public HomeController()
        {
            db = new WritingPadEntities();
        }
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            if(Session["LoginUser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
      
        }
        [HttpPost]
        public ActionResult Register(RegisterInsertModel model)
        {
            ViewBag.result = string.Empty;

            if (model.password != model.rePassword)
            {
                ViewBag.result = "Şifre eşleşmiyor.";
                return View();
            }

            //AppUser appUserEmail = db.AppUser.Where(c => c.Email.Equals(model.email)).SingleOrDefault();
            //AppUser appUserName = db.AppUser.Where(s => s.UserName.Equals(model.userName)).SingleOrDefault();
            //if(appUserEmail != null || appUserName != null)
            //{
            //    ViewBag.result = "Kullanıcı adı veya mail sistemde kayıtlı";
            //    return View();
            //}

            bool email = db.AppUser.Where(m => m.Email.Equals(model.email)).Any();
            bool userName = db.AppUser.Where(f => f.UserName.Equals(model.userName)).Any();
            if (email || userName)
            {
                ViewBag.result = "Kullanıcı adı ve ya mail sistemde kayıtlı";
                return View();
            }

            AppUser appUser = new AppUser()
            {
                Email = model.email,
                FullName = model.fullName,
                Pass = model.password,
                UserName = model.userName,
                IsActive = true
            };
            db.AppUser.Add(appUser);
            db.SaveChanges();
            return RedirectToAction("Login", "Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["LoginUser"] != null)//kullanıcı aktifse
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(string userName,string password)
        {
            AppUser appUser = db.AppUser.Where(s => s.UserName.Equals(userName) && s.Pass.Equals(password) && s.IsActive).SingleOrDefault();
            if( appUser!= null)
            {
                Session.Add("LoginUser", appUser);
            }
            else {
                ViewBag.result = "Kullanıcı bulunamıyor veya hesap aktif değil";
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}