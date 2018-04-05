using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppVue.Models
{
    public class Text
    {
        public int Cound { get; set; }
        public string Meassge { get; set; }
        public bool Souse { get; set; }
        public IList<IDictionary<string, object>> Lista { get; set; }
        public Text()
        {
            Cound = 200;
            Meassge = "";
            Souse = false;
        }
        public void File(string mes)
        {
            Meassge = mes;
        }
        public void File(string mas, int coud)
        {
            Meassge = mas;
            Cound = coud;
        }
        public void File(Exception ex)
        {
            File(ex.Message);
        }

    }
}