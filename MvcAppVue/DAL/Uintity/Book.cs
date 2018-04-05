using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppVue.DAL.Uintity
{
    public class Book
    {
        public int Bid { get; set; }
        public int Tid { get; set; }
        public string Bname { get; set; }
        public string Author { get; set; }
        public string Press { get; set; }
        public string Ifbname { get; set; }
        public DateTime Datatime { get; set; }
    }
}