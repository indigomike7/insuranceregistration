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
    public partial class OrderUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] != null && Request["action"] == "update" && !IsPostBack)
            {
                COrder oObj = new COrder(Convert.ToInt32(Request["id"]));
                full_name.Text = oObj.full_name;
                address.Text = oObj.address;
                zip_code.Text = oObj.zip_code;
                area.Text = oObj.area;
                country.Text = oObj.country;
                phone.Text = oObj.phone;
                mobile_phone.Text = oObj.mobile_phone;
                id_card_number.Text = oObj.id_card_number;
                birth_date.Text= oObj.birth_date.ToShortDateString() ;
                height.Text = oObj.height.ToString();
                weight.Text = oObj.weight.ToString();
                gender.SelectedValue = oObj.gender;
                marriage_status.Text = oObj.marriage_status;
                haji.SelectedValue = oObj.haji.ToString();
                pewaris_name.Text = oObj.pewaris_name;
                pewaris_id_card_number.Text = oObj.pewaris_id_card_number;
                pewaris_relation.Text = oObj.pewaris_relation;
                pewaris_gender.Text = oObj.pewaris_gender;
                pewaris_phone.Text = oObj.pewaris_phone;
                pewaris_payment_for.Text = oObj.pewaris_payment_for;
                order_money.Text = oObj.money.ToString();
                check_number.Text = oObj.check_number;
                order_name.Text = oObj.order_name;
                order_tarikh.Text = oObj.order_tarikh.ToShortDateString();
                order_kp_number.Text = oObj.order_kp_number;
                wakil_name.Text = oObj.wakil_name;
                wakil_tarikh.Text = oObj.wakil_tarikh.ToShortDateString();
                wakil_code.Text = oObj.wakil_code;
            }
            if (IsPostBack)
            {
                SubmitBtn_Click();
            }


        }
        [System.Web.Services.WebMethod]
        public static string Submit(string full_name, string user_password, bool ischecked)
        {
            string strErr = "";
            TextBox txt_login_email;
            TextBox txt_login_password;
            Page page = (Page)HttpContext.Current.Handler;

            //           string str_login_email = Microsoft.Security.Application.Encoder.JavaScriptEncode(user_name);
            //           string str_login_password = Microsoft.Security.Application.Encoder.JavaScriptEncode(user_password);

            //using (MD5 md5Hash = MD5.Create())
            //{
            //    CUser userObj = new CUser();
            //    string hash = userObj.GetMd5Hash(md5Hash, user_password);
            //    List<CUser> lstUser = new List<CUser>();
            //    lstUser = userObj.Login(user_name, hash);
            //    if (lstUser.Count() > 0)
            //    {
            //        Login objLogin = new Login();
            //        objLogin.RegisterSession(lstUser);
            //        if (ischecked == true)
            //        {
            //            Login objLogin2 = new Login();
            //            objLogin2.RegisterCookie(lstUser);
            //        }
            //    }
            //    else
            //    {
            //        strErr = "<div class='alert alert-danger'><i class='fa fa-bell-o'></i>  Username/Email and Password is wrong! </div>";
            //    }
            //}

            return strErr;
        }

        protected void SubmitBtn_Click()
        {
            if (Request["id"] != null && Request["action"] == "update")
            {
                try
                {
                    COrder oObj = new COrder();
                    oObj.full_name = full_name.Text;
                    oObj.address = address.Text;
                    oObj.zip_code = zip_code.Text;
                    oObj.area = area.Text;
                    oObj.country = country.Text;
                    oObj.phone = phone.Text;
                    oObj.mobile_phone = mobile_phone.Text;
                    oObj.id_card_number = id_card_number.Text;
                    oObj.birth_date = Convert.ToDateTime(birth_date.Text);
                    oObj.height = Convert.ToDecimal(height.Text);
                    oObj.weight = Convert.ToDecimal(weight.Text);
                    oObj.gender = gender.SelectedValue;
                    oObj.marriage_status = marriage_status.Text;
                    oObj.haji = Convert.ToInt32(haji.SelectedValue);
                    oObj.pewaris_name = pewaris_name.Text;
                    oObj.pewaris_id_card_number = pewaris_id_card_number.Text;
                    oObj.pewaris_relation = pewaris_relation.Text;
                    oObj.pewaris_gender = pewaris_gender.Text;
                    oObj.pewaris_phone = pewaris_phone.Text;
                    oObj.pewaris_payment_for = pewaris_payment_for.Text;
                    oObj.money = Convert.ToDecimal(order_money.Text);
                    oObj.check_number = check_number.Text;
                    oObj.order_name = order_name.Text;
                    oObj.order_tarikh = Convert.ToDateTime(order_tarikh.Text);
                    oObj.order_kp_number = order_kp_number.Text;
                    oObj.wakil_name = wakil_name.Text;
                    oObj.wakil_tarikh = Convert.ToDateTime(wakil_tarikh.Text);
                    oObj.wakil_code = wakil_code.Text;
                    oObj.created_by = (string)Session["user_name"];
                    oObj.created_date = DateTime.Now;
                    oObj.updated_by = (string)Session["user_name"];
                    oObj.updated_date = DateTime.Now;
                    oObj.order_id = Convert.ToInt32(Request["id"]);
                    oObj.Update();

                    ltrlmsg.Text = "<div class=\"alert alert-success\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>Success Update Order</div>";
                }
                catch (Exception ex)
                {
                    ltrlmsg.Text = "<div class=\"alert alert-danger\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>" + ex.Message + "</div>";
 
                }
            }
            else
            {
                try
                {
                    COrder oObj = new COrder();
                    oObj.full_name = full_name.Text;
                    oObj.address = address.Text;
                    oObj.zip_code = zip_code.Text;
                    oObj.area = area.Text;
                    oObj.country = country.Text;
                    oObj.phone = phone.Text;
                    oObj.mobile_phone = mobile_phone.Text;
                    oObj.id_card_number = id_card_number.Text;
                    oObj.birth_date = Convert.ToDateTime(birth_date.Text);
                    oObj.height = Convert.ToDecimal(height.Text);
                    oObj.weight = Convert.ToDecimal(weight.Text);
                    oObj.gender = gender.SelectedValue;
                    oObj.marriage_status = marriage_status.Text;
                    oObj.haji = Convert.ToInt32(haji.SelectedValue);
                    oObj.pewaris_name = pewaris_name.Text;
                    oObj.pewaris_id_card_number = pewaris_id_card_number.Text;
                    oObj.pewaris_relation = pewaris_relation.Text;
                    oObj.pewaris_gender = pewaris_gender.Text;
                    oObj.pewaris_phone = pewaris_phone.Text;
                    oObj.pewaris_payment_for = pewaris_payment_for.Text;
                    oObj.money = Convert.ToDecimal(order_money.Text);
                    oObj.check_number = check_number.Text;
                    oObj.order_name = order_name.Text;
                    oObj.order_tarikh = Convert.ToDateTime(order_tarikh.Text);
                    oObj.order_kp_number = order_kp_number.Text;
                    oObj.wakil_name = wakil_name.Text;
                    oObj.wakil_tarikh = Convert.ToDateTime(wakil_tarikh.Text);
                    oObj.wakil_code = wakil_code.Text;
                    oObj.created_by = (string)Session["user_name"];
                    oObj.created_date = DateTime.Now;
                    oObj.updated_by = (string)Session["user_name"];
                    oObj.updated_date = DateTime.Now;
                    oObj.Insert();

                    Response.Redirect("order.aspx");
                }
                catch (Exception ex)
                {
                    ltrlmsg.Text = "<div class=\"alert alert-danger\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>" + ex.Message + "</div>";
 
                }
            }
        }
    }
}