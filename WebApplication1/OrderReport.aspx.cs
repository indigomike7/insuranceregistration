using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.BLL;
using WebApplication1.DAL;
using CrystalDecisions.CrystalReports.Engine;

namespace WebApplication1
{
    public partial class OrderReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Submit();
            }

        }
        public void Submit()
        {
            COrder oObj = new COrder();
            List<COrder> oList = new List<COrder>();
            oList = oObj.GetReport1(Convert.ToDateTime(start_from.Text), Convert.ToDateTime(end_to.Text));
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/CrystalReport1.rpt"));
//            Customers dsCustomers = GetData();
            crystalReport.SetDataSource(oList);
            CrystalReportViewer1.ReportSource = crystalReport;

        }
    }
}