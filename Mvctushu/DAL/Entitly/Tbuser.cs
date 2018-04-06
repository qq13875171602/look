using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvctushu.DAL.Entitly
{
    public class Tbuser
    {
        public int Uid { get; set; }
        public string Uname { get; set; }
        public string Password { get; set; }
        public string Nick { get; set; }
        public string Ifuname { get; set; }
        public DateTime Datatime { get; set; }
    }
}