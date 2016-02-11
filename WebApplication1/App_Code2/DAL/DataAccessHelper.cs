using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;


/// <summary>
/// Summary description for DataAccessHelper
/// </summary>
namespace WebApplication1.DAL
{

    public abstract class DataAccessHelper : DataAccess
    {
        public DataAccessHelper() { }

        public static DataAccess GetDataAccess()
        {
            string dataAccessStringType = ConfigurationManager.AppSettings["aspnet_staterKits_TimeTracker_DataAccessLayerType"];
            if (String.IsNullOrEmpty(dataAccessStringType))
            {
                throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <connectionStrings> <add key=\"aspnet_staterKits_TimeTracker\" value=\"Server=(local);Integrated Security=True;Database=Issue_Tracker\" </connectionStrings>"));
            }
            else
            {
                Type dataAccessType = Type.GetType(dataAccessStringType);
                if (dataAccessType == null)
                {
                    throw (new NullReferenceException("DataAccessType can not be found"));
                }
                Type tp = Type.GetType("Chitato.DataAccessLayer.DataAccess");
                if (!tp.IsAssignableFrom(dataAccessType))
                {
                    throw (new ArgumentException("DataAccessType does not inherits from Chitato.DataAccessLayer.DataAccess "));

                }
                DataAccess dc = (DataAccess)Activator.CreateInstance(dataAccessType);
                return (dc);
            }
        }

        /*** PROPERTIES ***/
        protected static string ConnectionString
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["Reference.Connection"];
            }
        }

        /*** DELEGATE ***/

        public delegate void TGenerateListFromReader<T>(SqlDataReader returnData, ref List<T> tempList);

        /*****************************  SQL HELPER METHODS *****************************/

        public static void AddParamToSQLCmd(SqlCommand sqlCmd,
                                      string paramId,
                                      SqlDbType sqlType,
                                      int paramSize,
                                      ParameterDirection paramDirection,
                                      object paramvalue)
        {

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));
            if (paramId == string.Empty)
                throw (new ArgumentOutOfRangeException("paramId"));

            SqlParameter newSqlParam = new SqlParameter();
            newSqlParam.ParameterName = paramId;
            newSqlParam.SqlDbType = sqlType;
            newSqlParam.Direction = paramDirection;

            if (paramSize > 0)
                newSqlParam.Size = paramSize;

            if (paramvalue != null)
                newSqlParam.Value = paramvalue;

            sqlCmd.Parameters.Add(newSqlParam);
        }

        public static void ExecuteScalarCmd(SqlCommand sqlCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                sqlCmd.ExecuteScalar();
            }
        }

        public static object ExecuteScalarReturnValueCmd(SqlCommand sqlCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            object returnValue;

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                returnValue = sqlCmd.ExecuteScalar();
            }

            return returnValue;
        }

        public static DataSet ExecuteDatasetCmd(SqlCommand sqlCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                cn.Close();

                return ds;
            }
        }

        public static SqlDataReader ExecuteDataReaderCmd(SqlCommand sqlCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                //SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                SqlDataReader dr;
                dr = sqlCmd.ExecuteReader();
                //cn.Close();

                if (dr.Read())
                {

                }


                return dr;
            }
        }

        public static void SetCommandType(SqlCommand sqlCmd, CommandType cmdType, string cmdText)
        {
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandText = cmdText;
        }

        public static void TExecuteReaderCmd<T>(SqlCommand sqlCmd, TGenerateListFromReader<T> gcfr, ref List<T> List)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                sqlCmd.Connection = cn;

                cn.Open();

                gcfr(sqlCmd.ExecuteReader(), ref List);
            }
        }
    }
}
