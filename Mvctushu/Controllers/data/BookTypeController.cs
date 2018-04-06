using Mvctushu.DAL.DAO;
using Mvctushu.DAL.Entitly;
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
    public class BookTypeController : Controller
    {
        //
        // GET: /BookType/
        public ActionResult Index(Typemodel m)
        {
            try
            {
                TypeDAO.Add(m.Type);
                m.Message = "添加成功";
                m.Souse = true;
            }
            catch (Exception ex)
            {
                m.File(ex);
            }
            return Json(m);
        }

        public ActionResult Query(Typemodel m)
        {
            try
            {
                m.TypeList = TypeDAO.Query(m.Type);
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
