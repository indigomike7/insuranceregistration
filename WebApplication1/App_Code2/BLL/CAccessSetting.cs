
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
    public class CAccessSetting : DataAccessHelper
    {
        #region Variables
        private int _access_id;
        private string _access_name;
        private int _parent_id;
        private string _created_by;
        private DateTime _created_date;
        private string _updated_by;
        private DateTime _updated_date;

        #endregion

        #region Constructor
        public CAccessSetting()
        {
        }

        public CAccessSetting(int access_id)
        {
            List<CAccessSetting> asList = new List<CAccessSetting>();
            asList = this.GetAccessById(access_id);
            foreach (CAccessSetting acs in asList)
            {
                this.access_id = acs.access_id;
                this.access_name = acs.access_name;
                this.parent_id = acs.parent_id;
                this.created_by = acs.created_by;
                this.created_date = acs.created_date;
                this.updated_by = acs.updated_by;
                this.updated_date = acs.updated_date;
            }
        }
        #endregion

        #region Properties
        public int access_id
        {
            get { return _access_id; }
            set { _access_id = value; }
        }

        public string access_name
        {
            get { return _access_name; }
            set { _access_name = value; }
        }

        public int parent_id
        {
            get { return _parent_id; }
            set { _parent_id = value; }
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

        public List<CAccessSetting> GetAccessById(int access_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@access_id", SqlDbType.VarChar, 255, ParameterDirection.Input, access_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_access_by_id");
                ExecuteScalarCmd(sqlCmd);

                List<CAccessSetting> acsList = new List<CAccessSetting>();
                TExecuteReaderCmd<CAccessSetting>(sqlCmd, TGenerateNewsListFromReader<CAccessSetting>, ref acsList);
                return acsList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CAccessSetting> GetAccessAll()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_access_all");
                ExecuteScalarCmd(sqlCmd);

                List<CAccessSetting> acsList = new List<CAccessSetting>();
                TExecuteReaderCmd<CAccessSetting>(sqlCmd, TGenerateNewsListFromReader<CAccessSetting>, ref acsList);
                return acsList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CAccessSetting> GetAccessAllParent()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_access_parent");
                ExecuteScalarCmd(sqlCmd);

                List<CAccessSetting> acsList = new List<CAccessSetting>();
                TExecuteReaderCmd<CAccessSetting>(sqlCmd, TGenerateNewsListFromReader<CAccessSetting>, ref acsList);
                return acsList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CAccessSetting> GetAccessChildren(int parent_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@parent_id", SqlDbType.VarChar, 255, ParameterDirection.Input, parent_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_access_children");
                ExecuteScalarCmd(sqlCmd);

                List<CAccessSetting> acsList = new List<CAccessSetting>();
                TExecuteReaderCmd<CAccessSetting>(sqlCmd, TGenerateNewsListFromReader<CAccessSetting>, ref acsList);
                return acsList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static void TGenerateNewsListFromReader<T>(SqlDataReader returnData, ref List<CAccessSetting> acsList)
        {
            try
            {
                while (returnData.Read())
                {
                    CAccessSetting acs = new CAccessSetting();
                    if (returnData["access_id"] != DBNull.Value) acs.access_id = Convert.ToInt32(returnData["access_id"]);
                    if (returnData["access_name"] != DBNull.Value) acs.access_name = returnData["access_name"].ToString();
                    if( returnData["parent_id"]!= DBNull.Value) acs.parent_id = Convert.ToInt32(returnData["parent_id"].ToString());
                    if (returnData["created_by"] != DBNull.Value) acs.created_by = returnData["created_by"].ToString();
                    if (returnData["created_date"] != DBNull.Value) acs.created_date = Convert.ToDateTime(returnData["created_date"].ToString());
                    if (returnData["updated_by"] != DBNull.Value) acs.updated_by = returnData["updated_by"].ToString();
                    if (returnData["updated_date"] != DBNull.Value) acs.updated_date = Convert.ToDateTime(returnData["updated_date"].ToString());

                    acsList.Add(acs);
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
                AddParamToSQLCmd(sqlCmd, "@access_name", SqlDbType.VarChar, 255, ParameterDirection.Input, this.access_name);
                AddParamToSQLCmd(sqlCmd, "@parent_id", SqlDbType.Int, 0, ParameterDirection.Input, this.parent_id);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_access_insert");
                ExecuteScalarCmd(sqlCmd);

                this.access_id = Convert.ToInt32(sqlCmd.Parameters["@ReturnValue"].Value);
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

                AddParamToSQLCmd(sqlCmd, "@access_name", SqlDbType.VarChar, 255, ParameterDirection.Input, this.access_name);
                AddParamToSQLCmd(sqlCmd, "@parent_id", SqlDbType.Int, 0, ParameterDirection.Input, this.parent_id);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@access_id", SqlDbType.Int, 0, ParameterDirection.Input, this.access_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_access_update");
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

                AddParamToSQLCmd(sqlCmd, "@access_id", SqlDbType.Int, 0, ParameterDirection.Input, this.access_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_access_delete");
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