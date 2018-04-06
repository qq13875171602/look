using Mvctushu.DAL.DAO;
using Mvctushu.DAL.Uilty;
using Mvctushu.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvctushu.Controllers.data
{
    public class userController : Controller
    {
        //
        // GET: /user/
        public const string url = @"Username";
        public ActionResult Index(Usermodel m)
        {
            try
            {
                IDictionary<string, object> lk = UserDAO.Index(m.user);
                Session.Add(url, lk);
                m.Message = "登录成功";
                m.Souse = true;
            }
            catch (Exception ex)
            {
                m.File(ex);
            }
            return Json(m);
        }

        public static bool milp(HttpSessionStateBase http, Text t)
        {
            IDictionary<string, object> user = (IDictionary<string,object>)http[url];
            bool k = (user == null || user.Count == 0);
            if (k)
            {
                t.File("用户不存在", 501);
            }
            t.list = user;
            return k;
        }

        public ActionResult mook(Usermodel m)
        {
            if (userController.milp(Session, m))
            {
                return Json(m);
            }
            return Json(m);
        }

        public ActionResult Romve(Usermodel t)
        {
            Session.Remove(url);
            t.Souse = true;
            return Json(t);
        }

    }
}
