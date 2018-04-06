using Mvctushu.DAL.Entitly;
using Mvctushu.DAL.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvctushu.Models
{
    public class Typemodel:Text
    {
        public Booktype Type { get; set; }
        public IList<Booktype> TypeList { get; set; }

        public Typemodel()
        { 
        
        }
    }
}