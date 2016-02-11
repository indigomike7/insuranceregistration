
#region .NET Base Class Namespace Imports
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;
using WebApplication1.BLL;
using WebApplication1.DAL;
using System.Security.Cryptography;
using System.Text;
#endregion


namespace WebApplication1.BLL
{
    public class initz : System.Web.UI.Page
    {
        public CUserGroupMenu ugm = new CUserGroupMenu();
        public List<CUserGroupMenu> ugmList = new List<CUserGroupMenu>();
        public List<Dictionary<string, Object>> primary_nav = new List<Dictionary<string, Object>>();
        public initz()
        { 
            if((string)Session["user_id"]!= null)
            {
                ugmList = ugm.GetMenuByUser(Convert.ToInt32(Session["user_id"]));
            }
            Dictionary<string, Object> dashboard = new Dictionary<string,Object>();
//            dashboard["name"]="Dashboard";
            dashboard.Add("name","Dashboard");
            dashboard.Add("url","index.php");
            dashboard.Add("icon","fa fa-home");
            dashboard.Add("parent_id","0");
            dashboard.Add("menu_id","1");
            primary_nav.Add(dashboard);
            if (ugmList.Count > 0)
            {
                foreach (CUserGroupMenu ugmObj in ugmList)
                {
                    if (ugmObj.parent_id == 0)
                    {
                        Dictionary<string, Object> menu = new Dictionary<string, Object>();
                        menu.Add("name", ugmObj.menu_name);
                        menu.Add("url", ugmObj.menu_page);
                        menu.Add("icon", ugmObj.icon);
                        menu.Add("parent_id", ugmObj.parent_id);
                        menu.Add("menu_id", ugmObj.menu_id);
                        menu.Add("sub", new Dictionary<string,Object>());
                    }
                }
            }

            foreach(var x in primary_nav)
            {
                List<Dictionary<string, Object>> submenu = new List<Dictionary<string, Object>>();
                foreach (CUserGroupMenu ugmObj in ugmList)
                {
                    foreach(var y in  x)
                    {
                        if (y.Key == "parent_id" && Convert.ToInt32(y.Value.ToString()) == ugmObj.parent_id)
                        {
                            Dictionary<string, Object> menu = new Dictionary<string, Object>();
                            menu.Add("name", ugmObj.menu_name);
                            menu.Add("url", ugmObj.menu_page);
                            menu.Add("icon", ugmObj.icon);
                            menu.Add("parent_id", ugmObj.parent_id);
                            menu.Add("menu_id", ugmObj.menu_id);

                            submenu.Add(menu);
                        
                        }
                    }
                }
                x["sub"] = submenu;
            }
        }
    }
}