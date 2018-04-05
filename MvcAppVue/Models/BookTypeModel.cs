using MvcAppVue.DAL.Uintity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppVue.Models
{
    public class BookTypeModel:Text
    {
        public Booktype Booktype { get; set; }
        public IList<IDictionary<string, object>> List { get; set; }
        public BookTypeModel()
        {
            List = new List<IDictionary<string, object>>();
        }
    }
}