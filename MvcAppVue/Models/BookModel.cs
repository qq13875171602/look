using MvcAppVue.DAL.titly;
using MvcAppVue.DAL.Uintity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppVue.Models
{
    public class BookModel:Text
    {
        public Book book { get; set; }
        public IList<IDictionary<string, object>> list { get; set; }
        public IList<IDictionary<string, object>> Polki { get; set; }
        public Page page { get; set; }

        public BookModel()
        {
            list = new List<IDictionary<string, object>>();
            page = new Page();
        }
    }
}