using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.lang
{
    public class MyGeneral
    {
        public string order = "";
        public string order_report = "";
        public string language = "";
        public MyGeneral()
        {
            this.order= "Borang Permohonan";
            this.order_report = "Laporan Permohonan";
            this.language = "Bahasa";
        }
    }
}