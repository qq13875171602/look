using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvctushu.Models
{
    public class Text
    {
        public int Count { get; set; }
        public bool Souse { get; set; }
        public string Message { get; set; }
        public IDictionary<string, object> list { get; set; }
        public Text()
        {
            Count = 200;
            Souse = false;
            Message = "";
        }
        public void File(string mess, int count)
        {
            Count = count;
            Message = mess;
        }
        public void File(string meds)
        {
            File(meds, 501);
        }
        public void File(Exception e)
        {
            File(e.Message);
        }
    }
}