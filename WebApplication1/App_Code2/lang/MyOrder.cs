using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.lang
{
    public class MyOrder
    {
        public string order = "";
        public string order_name = "";
        public string order_date = "";
        public MyOrder()
        {
            this.order= "Borang Permohonan";
            this.order_name = "Borang Pemohon";
            this.order_date = "Tarikh Borang Permohonan";
        }
    }
}