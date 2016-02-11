using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.BLL;

namespace WebApplication1
{
    public partial class Order_delete_ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
//            if (IsPostBack)
//            {
                if (Request["id"] != null)
                {
                    COrder oObj = new COrder();
                    oObj.Delete(Convert.ToInt32(Request["id"].ToString()));
                }
 //           }

        }
    }
}