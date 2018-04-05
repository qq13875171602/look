using MvcAppVue.DAL.DAO;
using MvcAppVue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppVue.Controllers.Qiantai
{
    public class QianAddController : Controller
    {
        //
        // GET: /QianAdd/

        public ActionResult Index(userModel m)
        {
            try
            {
                ZhuceDAO.Add(m.user);
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
