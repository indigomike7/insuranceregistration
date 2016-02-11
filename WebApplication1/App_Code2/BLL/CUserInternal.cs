
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
    public class CUserInternal : DataAccessHelper
    {
        #region Variables
        private int _ui_id;
        private int _user_id;
        private string _ui_nip;
        private string _ui_jabatan;
        private string _ui_grade;
        private bool _status;
        private string _created_by;
        private DateTime _created_date;
        private string _updated_by;
        private DateTime _updated_date;

        #endregion

        #region Constructor
        public CUserInternal()
        {
        }

        public CUserInternal(int ui_id)
        {
            List<CUserInternal> uiList = new List<CUserInternal>();
            uiList = this.GetUiById(ui_id);
            foreach (CUserInternal ui in uiList)
            {
                this.ui_id = ui.ui_id;
                this.ui_nip = ui.ui_nip;
                this.ui_jabatan = ui.ui_jabatan;
                this.ui_grade = ui.ui_grade;
                this.status = ui.status;
                this.created_by = ui.created_by;
                this.created_date = ui.created_date;
                this.updated_by = ui.updated_by;
                this.updated_date = ui.updated_date;
            }
        }
        #endregion

        #region Properties
        public int ui_id
        {
            get { return _ui_id; }
            set { _ui_id = value; }
        }

        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        public string ui_nip
        {
            get { return _ui_nip; }
            set { _ui_nip = value; }
        }

        public string ui_jabatan
        {
            get { return _ui_jabatan; }
            set { _ui_jabatan = value; }
        }

        public string ui_grade
        {
            get { return _ui_grade; }
            set { _ui_grade = value; }
        }

        public bool status 
        {
            get { return _status; }
            set { _status = value; }
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

        public List<CUserInternal> GetUiById(int ui_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@ui_id", SqlDbType.VarChar, 255, ParameterDirection.Input, ui_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_ui_by_id");
                ExecuteScalarCmd(sqlCmd);

                List<CUserInternal> uiList = new List<CUserInternal>();
                TExecuteReaderCmd<CUserInternal>(sqlCmd, TGenerateNewsListFromReader<CUserInternal>, ref uiList);
                return uiList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CUserInternal> GetuiAll()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_ui_all");
                ExecuteScalarCmd(sqlCmd);

                List<CUserInternal> uiList = new List<CUserInternal>();
                TExecuteReaderCmd<CUserInternal>(sqlCmd, TGenerateNewsListFromReader<CUserInternal>, ref uiList);
                return uiList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        private static void TGenerateNewsListFromReader<T>(SqlDataReader returnData, ref List<CUserInternal> uiList)
        {
            try
            {
                while (returnData.Read())
                {
                    CUserInternal ui = new CUserInternal();
                    if (returnData["ui_id"] != DBNull.Value) ui.ui_id = Convert.ToInt32(returnData["ui_id"]);
                    if (returnData["user_id"] != DBNull.Value) ui.user_id = Convert.ToInt32(returnData["user_id"]);
                    if (returnData["ui_nip"] != DBNull.Value) ui.ui_nip = returnData["ui_nip"].ToString();
                    if (returnData["ui_jabatan"] != DBNull.Value) ui.ui_jabatan = returnData["ui_jabatan"].ToString();
                    if (returnData["ui_grade"] != DBNull.Value) ui.ui_grade = returnData["ui_grade"].ToString();
                    if (returnData["created_by"] != DBNull.Value) ui.created_by = returnData["created_by"].ToString();
                    if (returnData["created_date"] != DBNull.Value) ui.created_date = Convert.ToDateTime(returnData["created_date"].ToString());
                    if (returnData["updated_by"] != DBNull.Value) ui.updated_by = returnData["updated_by"].ToString();
                    if (returnData["updated_date"] != DBNull.Value) ui.updated_date = Convert.ToDateTime(returnData["updated_date"].ToString());

                    uiList.Add(ui);
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
                AddParamToSQLCmd(sqlCmd, "@user_id", SqlDbType.Int, 0, ParameterDirection.Input, this.user_id);
                AddParamToSQLCmd(sqlCmd, "@ui_nip", SqlDbType.VarChar, 255, ParameterDirection.Input, this.ui_nip);
                AddParamToSQLCmd(sqlCmd, "@ui_jabatan", SqlDbType.VarChar, 255, ParameterDirection.Input, this.ui_jabatan);
                AddParamToSQLCmd(sqlCmd, "@ui_grade", SqlDbType.VarChar, 255, ParameterDirection.Input, this.ui_grade);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_ui_insert");
                ExecuteScalarCmd(sqlCmd);

                this.ui_id = Convert.ToInt32(sqlCmd.Parameters["@ReturnValue"].Value);
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

                AddParamToSQLCmd(sqlCmd, "@user_id", SqlDbType.Int, 0, ParameterDirection.Input, this.user_id);
                AddParamToSQLCmd(sqlCmd, "@ui_nip", SqlDbType.VarChar, 255, ParameterDirection.Input, this.ui_nip);
                AddParamToSQLCmd(sqlCmd, "@ui_jabatan", SqlDbType.VarChar, 255, ParameterDirection.Input, this.ui_jabatan);
                AddParamToSQLCmd(sqlCmd, "@ui_grade", SqlDbType.VarChar, 255, ParameterDirection.Input, this.ui_grade);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@ui_id", SqlDbType.Int, 0, ParameterDirection.Input, this.ui_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_ui_update");
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

                AddParamToSQLCmd(sqlCmd, "@ui_id", SqlDbType.Int, 0, ParameterDirection.Input, this.ui_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_ui_delete");
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