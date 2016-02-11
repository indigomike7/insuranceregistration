
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
    /// <summary>
    /// Summary description for CCommunity
    /// </summary>
    /// 
    [Serializable()]
    public class CMenu : DataAccessHelper
    {
        #region Variables
        private int _menu_id;
        private string _menu_name;
        private string _menu_page;
        private int _parent_id;
        private string _icon;
        private string _created_by;
        private DateTime _created_date;
        private string _updated_by;
        private DateTime _updated_date;
        private string _parent_name;

        #endregion

        #region Constructor
        public CMenu()
        {
        }

        public CMenu(int menu_id)
        {
            List<CMenu> menuList = new List<CMenu>();
            menuList=this.GetMenuById(menu_id);
            foreach(CMenu menu in menuList)
            {
                this.menu_id = menu.menu_id;
                this.menu_name = menu.menu_name;
                this.menu_page = menu.menu_page;
                this.parent_id = menu.parent_id;
                this.icon = menu.icon;
                this.created_by = menu.created_by;
                this.created_date = menu.created_date;
                this.updated_by = menu.updated_by;
                this.updated_date = menu.updated_date;
                this.parent_name = menu.parent_name;
            }
        }
        #endregion

        #region Properties
        public int menu_id
        {
            get { return _menu_id; }
            set { _menu_id = value; }
        }

        public string menu_name
        {
            get { return _menu_name; }
            set { _menu_name = value; }
        }

        public string menu_page
        {
            get { return _menu_page; }
            set { _menu_page = value; }
        }

        public int parent_id
        {
            get { return _parent_id; }
            set { _parent_id = value; }
        }

        public string icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public string created_by
        {
            get { return _created_by; }
            set { _created_by = value; }
        }

        public DateTime created_date
        {
            get { return _created_date; }
            set { _created_date = value; }
        }

        public string updated_by
        {
            get { return _updated_by; }
            set { _updated_by = value; }
        }
        public DateTime updated_date
        {
            get { return _updated_date; }
            set { _updated_date = value; }
        }
        public string parent_name 
        { 
            get { return _parent_name;  }
            set { _parent_name = value; }
        }
#endregion
        #region Method

        public List<CMenu> GetMenuById(int menu_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@menu_id", SqlDbType.VarChar, 255, ParameterDirection.Input, menu_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_menu_by_id");
                ExecuteScalarCmd(sqlCmd);

                List<CMenu> menuList = new List<CMenu>();
                TExecuteReaderCmd<CMenu>(sqlCmd, TGenerateNewsListFromReader<CMenu>, ref menuList);
                return menuList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CMenu> GetMenuAll()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_menu_all");
                ExecuteScalarCmd(sqlCmd);

                List<CMenu> menuList = new List<CMenu>();
                TExecuteReaderCmd<CMenu>(sqlCmd, TGenerateNewsListFromReader<CMenu>, ref menuList);
                return menuList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public List<CMenu> GetMenuParent()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_menu_parent");
                ExecuteScalarCmd(sqlCmd);

                List<CMenu> menuList = new List<CMenu>();
                TExecuteReaderCmd<CMenu>(sqlCmd, TGenerateNewsListFromReader<CMenu>, ref menuList);
                return menuList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public List<CMenu> GetMenuChildren(int parent_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@parent_id", SqlDbType.VarChar, 255, ParameterDirection.Input, parent_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_menu_by_id");
                ExecuteScalarCmd(sqlCmd);

                List<CMenu> menuList = new List<CMenu>();
                TExecuteReaderCmd<CMenu>(sqlCmd, TGenerateNewsListFromReader<CMenu>, ref menuList);
                return menuList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static void TGenerateNewsListFromReader<T>(SqlDataReader returnData, ref List<CMenu> menuList)
        {
            try
            {
                while (returnData.Read())
                {
                    CMenu menu = new CMenu();
                    if (returnData["menu_id"] != DBNull.Value) menu.menu_id = Convert.ToInt32(returnData["menu_id"]);
                    if (returnData["menu_name"] != DBNull.Value) menu.menu_name = returnData["menu_name"].ToString();
                    if (returnData["menu_page"] != DBNull.Value) menu.menu_page = returnData["menu_page"].ToString();
                    if (returnData["parent_id"] != DBNull.Value) menu.parent_id = Convert.ToInt32(returnData["parent_id"].ToString());
                    if (returnData["icon"] != DBNull.Value) menu.icon = returnData["icon"].ToString();
                    if (returnData["created_by"] != DBNull.Value) menu.created_by = returnData["created_by"].ToString();
                    if (returnData["created_date"] != DBNull.Value) menu.created_date = Convert.ToDateTime(returnData["created_date"].ToString());
                    if (returnData["updated_by"] != DBNull.Value) menu.updated_by = returnData["updated_by"].ToString();
                    if (returnData["updated_date"] != DBNull.Value) menu.updated_date = Convert.ToDateTime(returnData["updated_date"].ToString());
                    if(returnData["parent_name"]!=DBNull.Value) menu.parent_name = returnData["parent_name"].ToString();

                    menuList.Add(menu);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Insert()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.ReturnValue, null);
                AddParamToSQLCmd(sqlCmd, "@menu_name", SqlDbType.VarChar, 255, ParameterDirection.Input, this.menu_name);
                AddParamToSQLCmd(sqlCmd, "@menu_page", SqlDbType.VarChar, 255, ParameterDirection.Input, this.menu_page);
                AddParamToSQLCmd(sqlCmd, "@parent_id", SqlDbType.Int, 0, ParameterDirection.Input, this.parent_id);
                AddParamToSQLCmd(sqlCmd, "@icon", SqlDbType.VarChar, 255, ParameterDirection.Input, this.icon);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_menu_insert");
                ExecuteScalarCmd(sqlCmd);

                this.menu_id = Convert.ToInt32(sqlCmd.Parameters["@ReturnValue"].Value);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Update()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@menu_name", SqlDbType.VarChar, 255, ParameterDirection.Input, this.menu_name);
                AddParamToSQLCmd(sqlCmd, "@menu_page", SqlDbType.VarChar, 255, ParameterDirection.Input, this.menu_page);
                AddParamToSQLCmd(sqlCmd, "@parent_id", SqlDbType.Int, 0, ParameterDirection.Input, this.parent_id);
                AddParamToSQLCmd(sqlCmd, "@icon", SqlDbType.VarChar, 255, ParameterDirection.Input, this.icon);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@menu_id", SqlDbType.Int, 0, ParameterDirection.Input, this.menu_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_menu_update");
                ExecuteScalarCmd(sqlCmd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Delete()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@menu_id", SqlDbType.Int, 0, ParameterDirection.Input, this.menu_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_menu_delete");
                ExecuteScalarCmd(sqlCmd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion
    }
}