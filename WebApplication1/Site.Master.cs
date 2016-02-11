using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.BLL;
using WebApplication1.DAL;

namespace WebApplication1
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["lang"] != null)
            {
                if (Request["lang"] == "en")
                {
                    Session["lang"] = "en";
                }
                else
                {
                    Session["lang"] = "my";
                }
            }
            if (HttpContext.Current.Request.Cookies["user_email"]!=null && Session["user_name"]==null)
            {
                CUser userObj = new CUser();
                List<CUser> lstUser=new List<CUser>();
                lstUser=userObj.GetUserByEmail(HttpContext.Current.Request.Cookies["user_email"].Value);
                if (lstUser.Count() > 0)
                {
                    RegisterSession(lstUser);
                    //throw new Exception("cookies");
                }

            }

            if ((string)Session["user_email"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            //initz initObj = new initz();
            //List<Dictionary<string, Object>> primary_nav = new List<Dictionary<string, object>>();
            //primary_nav = initObj.primary_nav;
        }
        protected void RegisterSession(List<CUser> userlist)
        {
            foreach (CUser user in userlist)
            {
                Session["user_email"] = user.user_email;
                Session["user_name"] = user.user_name;
                Session["user_id"] = user.user_id;
                Session["user_group_id"] = user.user_group_id;
                Session["user_first_name"] = user.user_first_name;
                Session["user_last_name"] = user.user_last_name;
            }

        }

    }
}
