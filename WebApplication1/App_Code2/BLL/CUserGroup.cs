
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
    public class CUserGroup : DataAccessHelper
    {
        #region Variables
        private int _user_group_id;
        private string _user_group_name;
        private string _created_by;
        private DateTime _created_date;
        private string _updated_by;
        private DateTime _updated_date;

        #endregion

        #region Constructor
        public CUserGroup()
        {
        }

        public CUserGroup(int user_group_id)
        {
            List<CUserGroup> ugList = new List<CUserGroup>();
            ugList = this.GetUserGroupById(user_group_id);
            foreach (CUserGroup ug in ugList)
            {
                this.user_group_id = ug.user_group_id;
                this.user_group_name = ug.user_group_name;
                this.created_by = ug.created_by;
                this.created_date = ug.created_date;
                this.updated_by = ug.updated_by;
                this.updated_date = ug.updated_date;
            }
        }
        #endregion

        #region Properties
        public int user_group_id
        {
            get { return _user_group_id; }
            set { _user_group_id = value; }
        }

        public string user_group_name
        {
            get { return _user_group_name; }
            set { _user_group_name = value; }
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
        #endregion

        #region Method

        public List<CUserGroup> GetUserGroupById(int user_group_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@user_group_id", SqlDbType.VarChar, 255, ParameterDirection.Input, user_group_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_user_group_by_id");
                ExecuteScalarCmd(sqlCmd);

                List<CUserGroup> ugList = new List<CUserGroup>();
                TExecuteReaderCmd<CUserGroup>(sqlCmd, TGenerateNewsListFromReader<CUserGroup>, ref ugList);
                return ugList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CUserGroup> GetUserGroupAll()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_user_group_all");
                ExecuteScalarCmd(sqlCmd);

                List<CUserGroup> ugList = new List<CUserGroup>();
                TExecuteReaderCmd<CUserGroup>(sqlCmd, TGenerateNewsListFromReader<CUserGroup>, ref ugList);
                return ugList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static void TGenerateNewsListFromReader<T>(SqlDataReader returnData, ref List<CUserGroup> ugList)
        {
            try
            {
                while (returnData.Read())
                {
                    CUserGroup ug = new CUserGroup();
                    if (returnData["user_group_id"] != DBNull.Value) ug.user_group_id = Convert.ToInt32(returnData["user_group_id"]);
                    if (returnData["user_group_name"] != DBNull.Value) ug.user_group_name = returnData["user_group_name"].ToString();
                    if (returnData["created_by"] != DBNull.Value) ug.created_by = returnData["created_by"].ToString();
                    if (returnData["created_date"] != DBNull.Value) ug.created_date = Convert.ToDateTime(returnData["created_date"].ToString());
                    if (returnData["updated_by"] != DBNull.Value) ug.updated_by = returnData["updated_by"].ToString();
                    if (returnData["updated_date"] != DBNull.Value) ug.updated_date = Convert.ToDateTime(returnData["updated_date"].ToString());

                    ugList.Add(ug);
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
                AddParamToSQLCmd(sqlCmd, "@user_group_name", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_group_name);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_user_group_insert");
                ExecuteScalarCmd(sqlCmd);

                this.user_group_id = Convert.ToInt32(sqlCmd.Parameters["@ReturnValue"].Value);
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

                AddParamToSQLCmd(sqlCmd, "@user_group_name", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_group_name);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@user_group_id", SqlDbType.Int, 0, ParameterDirection.Input, this.user_group_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_user_group_update");
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

                AddParamToSQLCmd(sqlCmd, "@user_group_id", SqlDbType.Int, 0, ParameterDirection.Input, this.user_group_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_user_group_delete");
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