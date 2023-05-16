using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class Medicine
    {
        public string medicineid { set; get; }
        public string medicinename { set; get; }
        public string companyid { set; get; }
        public float price { set; get; }
        public DateTime manufactuting  { set; get; }
        public DateTime expired  { set; get; }
        public int quantity  { set; get; }
    }
}
