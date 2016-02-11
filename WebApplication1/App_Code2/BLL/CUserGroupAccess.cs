
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
    public class CUserGroupAccess : DataAccessHelper
    {
        #region Variables
        private int _uga_id;
        private int _user_group_id;
        private int _access_id;
        private string _created_by;
        private DateTime _created_date;
        private string _updated_by;
        private DateTime _updated_date;

        #endregion

        #region Constructor
        public CUserGroupAccess()
        {
        }

        #endregion

        #region Properties
        public int uga_id
        {
            get { return _uga_id; }
            set { _uga_id = value; }
        }

        public int user_group_id
        {
            get { return _user_group_id; }
            set { _user_group_id = value; }
        }

        public int access_id
        {
            get { return _access_id; }
            set { _access_id = value; }
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

        public List<CUserGroupAccess> GetMenuByUser(int user_group_id,int access_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@user_group_id", SqlDbType.Int, 0, ParameterDirection.Input, user_group_id);
                AddParamToSQLCmd(sqlCmd, "@access_id", SqlDbType.Int, 0, ParameterDirection.Input, access_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_uga_1");
                ExecuteScalarCmd(sqlCmd);

                List<CUserGroupAccess> ugaList = new List<CUserGroupAccess>();
                TExecuteReaderCmd<CUserGroupAccess>(sqlCmd, TGenerateNewsListFromReader<CUserGroupAccess>, ref ugaList);
                return ugaList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CUserGroupAccess> Get1(string access_name, int user_group_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@access_name", SqlDbType.VarChar, 255, ParameterDirection.Input, access_name);
                AddParamToSQLCmd(sqlCmd, "@user_group_id", SqlDbType.Int,0, ParameterDirection.Input, user_group_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_uga_2");
                ExecuteScalarCmd(sqlCmd);

                List<CUserGroupAccess> ugaList = new List<CUserGroupAccess>();
                TExecuteReaderCmd<CUserGroupAccess>(sqlCmd, TGenerateNewsListFromReader<CUserGroupAccess>, ref ugaList);
                return ugaList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static void TGenerateNewsListFromReader<T>(SqlDataReader returnData, ref List<CUserGroupAccess> ugaList)
        {
            try
            {
                while (returnData.Read())
                {
                    CUserGroupAccess uga = new CUserGroupAccess();
                    if (returnData["uga_id"] != DBNull.Value) uga.uga_id = Convert.ToInt32(returnData["uga_id"]);
                    if (returnData["user_group_id"] != DBNull.Value) uga.user_group_id = Convert.ToInt32(returnData["user_group_id"]);
                    if (returnData["access_id"] != DBNull.Value) uga.access_id = Convert.ToInt32(returnData["access_id"]);
                    if (returnData["created_by"] != DBNull.Value) uga.created_by = returnData["created_by"].ToString();
                    if (returnData["created_date"] != DBNull.Value) uga.created_date = Convert.ToDateTime(returnData["created_date"].ToString());
                    if (returnData["updated_by"] != DBNull.Value) uga.updated_by = returnData["updated_by"].ToString();
                    if (returnData["updated_date"] != DBNull.Value) uga.updated_date = Convert.ToDateTime(returnData["updated_date"].ToString());

                    ugaList.Add(uga);
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
                AddParamToSQLCmd(sqlCmd, "@access_id", SqlDbType.Int, 0, ParameterDirection.Input, this.access_id);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_uga_insert");
                ExecuteScalarCmd(sqlCmd);

                this.access_id = Convert.ToInt32(sqlCmd.Parameters["@ReturnValue"].Value);
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
                AddParamToSQLCmd(sqlCmd, "@access_id", SqlDbType.Int, 0, ParameterDirection.Input, this.access_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_uga_delete");
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