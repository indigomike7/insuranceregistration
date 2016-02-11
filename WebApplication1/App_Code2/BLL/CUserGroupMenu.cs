
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
    public class CUserGroupMenu : DataAccessHelper
    {
        #region Variables
        private int _ugm_id;
        private int _user_group_id;
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
        public CUserGroupMenu()
        {
        }

        #endregion

        #region Properties
        public int ugm_id
        {
            get { return _ugm_id; }
            set { _ugm_id = value; }
        }

        public int user_group_id
        {
            get { return _user_group_id; }
            set { _user_group_id = value; }
        }

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
            get { return _parent_name; }
            set { _parent_name = value; }
        }
        #endregion
        #region Method

        public List<CUserGroupMenu> GetMenuByUser(int user_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@user_id", SqlDbType.VarChar, 255, ParameterDirection.Input, user_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_ugm_all");
                ExecuteScalarCmd(sqlCmd);

                List<CUserGroupMenu> ugmList = new List<CUserGroupMenu>();
                TExecuteReaderCmd<CUserGroupMenu>(sqlCmd, TGenerateNewsListFromReader<CUserGroupMenu>, ref ugmList);
                return ugmList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CUserGroupMenu> Get1(int menu_id, int user_group_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@menu_id", SqlDbType.Int,0, ParameterDirection.Input, menu_id);
                AddParamToSQLCmd(sqlCmd, "@user_group_id", SqlDbType.Int, 0, ParameterDirection.Input, user_group_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_ugm_1");
                ExecuteScalarCmd(sqlCmd);

                List<CUserGroupMenu> ugmList = new List<CUserGroupMenu>();
                TExecuteReaderCmd<CUserGroupMenu>(sqlCmd, TGenerateNewsListFromReader<CUserGroupMenu>, ref ugmList);
                return ugmList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static void TGenerateNewsListFromReader<T>(SqlDataReader returnData, ref List<CUserGroupMenu> ugmList)
        {
            try
            {
                while (returnData.Read())
                {
                    CUserGroupMenu ugm = new CUserGroupMenu();
                    if (returnData["ugm_id"] != DBNull.Value) ugm.ugm_id = Convert.ToInt32(returnData["ugm_id"]);
                    if (returnData["user_group_id"] != DBNull.Value) ugm.user_group_id = Convert.ToInt32(returnData["user_group_id"]);
                    if (returnData["menu_id"] != DBNull.Value) ugm.menu_id = Convert.ToInt32(returnData["menu_id"]);
                    if (returnData["menu_id"] != DBNull.Value) ugm.menu_id = Convert.ToInt32(returnData["menu_id"]);
                    if (returnData["menu_name"] != DBNull.Value) ugm.menu_name = returnData["menu_name"].ToString();
                    if (returnData["menu_page"] != DBNull.Value) ugm.menu_page = returnData["menu_page"].ToString();
                    if (returnData["parent_id"] != DBNull.Value) ugm.parent_id = Convert.ToInt32(returnData["parent_id"].ToString());
                    if (returnData["icon"] != DBNull.Value) ugm.icon = returnData["icon"].ToString();
                    if (returnData["created_by"] != DBNull.Value) ugm.created_by = returnData["created_by"].ToString();
                    if (returnData["created_date"] != DBNull.Value) ugm.created_date = Convert.ToDateTime(returnData["created_date"].ToString());
                    if (returnData["updated_by"] != DBNull.Value) ugm.updated_by = returnData["updated_by"].ToString();
                    if (returnData["updated_date"] != DBNull.Value) ugm.updated_date = Convert.ToDateTime(returnData["updated_date"].ToString());

                    ugmList.Add(ugm);
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
                AddParamToSQLCmd(sqlCmd, "@user_group_id", SqlDbType.Int, 0, ParameterDirection.Input, this.user_group_id);
                AddParamToSQLCmd(sqlCmd, "@menu_id", SqlDbType.Int,0, ParameterDirection.Input, this.menu_id);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_ugm_insert");
                ExecuteScalarCmd(sqlCmd);

                this.menu_id = Convert.ToInt32(sqlCmd.Parameters["@ReturnValue"].Value);
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

                AddParamToSQLCmd(sqlCmd, "@user_group_id", SqlDbType.Int, 0, ParameterDirection.Input, this.user_group_id);
                AddParamToSQLCmd(sqlCmd, "@menu_id", SqlDbType.Int, 0, ParameterDirection.Input, this.menu_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_ugm_delete");
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