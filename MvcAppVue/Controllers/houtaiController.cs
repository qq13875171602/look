using MvcAppVue.DAL.DAO;
using MvcAppVue.DAL.Uintity;
using MvcAppVue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppVue.Controllers
{
    public class houtaiController : Controller
    {
        //
        // GET: /houtai/

        public ActionResult Index(BookTypeModel m)
        {
            try
            {
                TypeDAO.Add(m.Booktype);
                m.Souse = true;
            }
            catch (Exception ex)
            {
                m.File(ex);
            }
            return Json(m);
        }

        public ActionResult Query(BookTypeModel m)
        {
            try
            {
                m.List = TypeDAO.list();
                m.Souse = true;
            }
            catch (Exception ex)
            {
                m.File(ex);
            }
            return Json(m);
        }

        public ActionResult Add(BookModel m)
        {
            try
            {
                bookDAO.Add(m.book);
                m.Souse = true;
            }
            catch (Exception ex)
            {
                m.File(ex);
            }
            return Json(m);
        }

        public ActionResult select(BookModel m)
        {
            try
            {
                m.list=bookDAO.Query(m.page);
                m.Souse = true;
            }
            catch (Exception ex)
            {
                m.File(ex);
            }
            return Json(m);
        }

        public ActionResult delete(BookModel m)
        {
            try
            {
                bookDAO.DEteup(m.book);
                m.Souse = true;
            }
            catch (Exception ex)
            {
                m.File(ex);
            }
            return Json(m);
        }

        public ActionResult mohu(BookModel m)
        {
            try
            {
                m.Polki = bookDAO.list(m.book);
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
