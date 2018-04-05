using MvcAppVue.DAL.DAO;
using MvcAppVue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppVue.Controllers
{
    public class zhuceController : Controller
    {
        //
        // GET: /zhuce/

        public ActionResult Index(userModel m)
        {
            try
            {
                add.Add(m.user);
                m.Souse = true;
            }
            catch (Exception ex)
            {
                m.File(ex);
            }
            return Json(m);
        }

    }
}
