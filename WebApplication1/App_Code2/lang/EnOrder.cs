using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.lang
{
    public class EnOrder
    {
        public string order = "";
        public string order_name = "";
        public string order_date = "";
        public EnOrder()
        {
            this.order= "Application Form";
            this.order_name = "Name Who Order";
            this.order_date = "Order Date";
        }
    }
}