using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WritingPad.BIZ;
using WritingPad.DATA;

namespace WritingPad.WEB.Controllers
{
    public class HomeController : Controller
    {
        AppUserOperation appUserOperation;

        public HomeController()
        {
            appUserOperation = new AppUserOperation();
        }

        public ActionResult Index()
        {
            List<AppUser> appuserList = appUserOperation.GetAll();
            return View(appuserList);
        }
    }
}