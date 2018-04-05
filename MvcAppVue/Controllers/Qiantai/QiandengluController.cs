using MvcAppVue.DAL.DAO;
using MvcAppVue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppVue.Controllers.Qiantai
{
    public class QiandengluController : Controller
    {
        //
        // GET: /Qiandenglu/

        public ActionResult Index(userModel m)
        {
            try
            {
               IDictionary<string,object> user=QiandengluDAO.Query(m.user);
               if (user == null || user.Count==0)
               {
                   m.File("用户名或密码错误");
               }
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
