using Mvctushu.Controllers.data;
using Mvctushu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvctushu.Controllers.page
{
    public class houtaiController : Controller
    {
        //
        // GET: /houtai/

        public ActionResult Index()
        {
            //if (userController.milp(Session, new Text()))
            //{
            //    return RedirectToAction("Index", "adminUser");
            //}
            return View();
        }

        public ActionResult TypeAdd()
        {
            //if (userController.milp(Session, new Text()))
            //{
            //    return RedirectToAction("Index", "adminUser");
            //}
            return View();
        }

    }
}
