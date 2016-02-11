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
    public partial class Password_update_personal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SubmitBtn_Click();
            }

        }
        protected void SubmitBtn_Click()
        {
            CUser user = new CUser();
            List<CUser> userList = new List<CUser>();
            userList=user.GetUserById(Convert.ToInt32(Session["user_id"]));
            MD5 md5hash = MD5.Create();
            if (userList.Count > 0 )
            {
                try
                {
                    bool found = false;
                    foreach (CUser u in userList)
                    {
                        if (u.user_password == user.GetMd5Hash(md5hash, old_password.Text))
                        {
                            user.user_id = Convert.ToInt32(Session["user_id"]);
                            user.updated_by = (string)Session["user_name"];
                            user.user_password = user.GetMd5Hash(md5hash, new_password.Text);
                            user.UpdatePassword();
                            found = true;
                            ltrlmsg.Text = "<div class=\"alert alert-success\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button> Password Update Success</div>";
                        }
                    }
                    if (found == false)
                    {
                        ltrlmsg.Text = "<div class=\"alert alert-danger\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button> Old Password Error</div>";
                    }
                }
                catch (Exception ex)
                {
                    ltrlmsg.Text = "<div class=\"alert alert-danger\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button> " + ex.Message + "</div>";
                }
            }
        }
    }
}