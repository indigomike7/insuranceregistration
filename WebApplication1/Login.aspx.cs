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
    public partial class Login : System.Web.UI.Page
    {
        public string user_email;
        public string user_password;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["user_email"] != null)
            {
                Response.Redirect("Default.aspx");
            }
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
        protected void RegisterCookie(List<CUser> userlist)
        {
            Page page = (Page)HttpContext.Current.Handler;
            foreach (CUser user in userlist)
            {
                HttpCookie aCookie = new HttpCookie("user_name");
                aCookie.Value = user.user_name;
                aCookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(aCookie);

                HttpCookie aCookie2 = new HttpCookie("user_email");
                aCookie2.Value = user.user_email;
                aCookie2.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(aCookie2);
                
                HttpCookie aCookie3 = new HttpCookie("user_id");
                aCookie3.Value = user.user_id.ToString();
                aCookie3.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(aCookie3);

                HttpCookie aCookie4 = new HttpCookie("user_group_id");
                aCookie4.Value = user.user_id.ToString();
                aCookie4.Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies.Add(aCookie4);
            }

        }
        [System.Web.Services.WebMethod]
        public static string Submit(string user_name,string user_password, bool ischecked)
        {
            string strErr = "";
            TextBox txt_login_email;
            TextBox txt_login_password;
            Page page = (Page)HttpContext.Current.Handler;
            if (user_name.Trim() == "" || user_password.Trim() == "")
            {
                strErr = "<div class='alert alert-danger'><i class='fa fa-bell-o'></i>  Username/Email or Password still empty! </div>";
            }
            else
            {

                //           string str_login_email = Microsoft.Security.Application.Encoder.JavaScriptEncode(user_name);
                //           string str_login_password = Microsoft.Security.Application.Encoder.JavaScriptEncode(user_password);

                using (MD5 md5Hash = MD5.Create())
                {
                    CUser userObj = new CUser();
                    string hash = userObj.GetMd5Hash(md5Hash, user_password);
                    List<CUser> lstUser = new List<CUser>();
                    lstUser = userObj.Login(user_name, hash);
                    if (lstUser.Count() > 0)
                    {
                        Login objLogin = new Login();
                        objLogin.RegisterSession(lstUser);
                        if (ischecked == true)
                        {
                            Login objLogin2 = new Login();
                            objLogin2.RegisterCookie(lstUser);
                        }
                    }
                    else
                    {
                        strErr = "<div class='alert alert-danger'><i class='fa fa-bell-o'></i>  Username/Email and Password is wrong! </div>";
                    }
                }

            }
            return strErr;
        }
    }
}