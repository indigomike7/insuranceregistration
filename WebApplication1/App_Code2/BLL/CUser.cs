
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
    public class CUser : DataAccessHelper
    {
        #region Variables
        private int _user_id;
        private string _user_name;
        private string _user_email;
        private string _user_first_name;
        private string _user_last_name;
        private string _user_password;
        private DateTime _user_last_login;
        private int _user_group_id;
        private string _user_birth_place;
        private DateTime _user_birth_date;
        private string _user_address;
        private string _user_social_number;
        private string _user_phone_number;
        private string _user_id_card_file;
        private string _user_photo_file;
        private string _user_gender;
        private string _user_marital_status;
        private string _created_by;
        private DateTime _created_date;
        private string _updated_by;
        private DateTime _updated_date;
        private string _user_group_name;


        #endregion

        #region Constructor
        public CUser()
        {
        }

        public CUser(int user_id)
        {
            List<CUser> userList = new List<CUser>();
            userList =GetUserById(user_id);
            foreach (CUser user in userList)
            {
                this.user_id=user.user_id;
                this.user_name=user.user_name;
                this.user_email=user.user_name;
                this.user_first_name=user.user_first_name;
                this.user_last_name=user.user_last_name;
                this.user_password=user.user_password;
                this.user_last_login=user.user_last_login;
                this.user_group_id=user.user_group_id;
                this.user_birth_place=user.user_birth_place;
                this.user_birth_date=user.user_birth_date;
                this.user_address=user.user_address;
                this.user_social_number=user.user_social_number;
                this.user_phone_number=user.user_phone_number;
                this.user_id_card_file=user.user_id_card_file;
                this.user_photo_file=user._user_photo_file;
                this.user_gender=user.user_gender;
                this.user_marital_status=user.user_marital_status;
                this.created_by=user.created_by;
                this.created_date=user.created_date;
                this.updated_by=user.updated_by;
                this.updated_date=user.updated_date;
                this.user_group_name=user.user_group_name;
            }
        }
        #endregion

        #region Properties
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        public string user_name
        {
            get { return _user_name; }
            set { _user_name = value; }
        }

        public string user_email
        {
            get { return _user_email; }
            set { _user_email = value; }
        }

        public string user_password
        {
            get { return _user_password; }
            set { _user_password = value; }
        }

        public string user_first_name
        {
            get { return _user_first_name; }
            set { _user_first_name = value; }
        }

        public string user_last_name
        {
            get { return _user_last_name; }
            set { _user_last_name = value; }
        }

        public DateTime user_last_login
        {
            get { return _user_last_login; }
            set { _user_last_login = value; }
        }

        public int user_group_id
        {
            get { return _user_group_id; }
            set { _user_group_id = value; }
        }
 
        public string user_birth_place
        {
            get { return _user_birth_place; }
            set { _user_birth_place = value; }
        }

        public DateTime user_birth_date
        {
            get { return _user_birth_date; }
            set { _user_birth_date = value; }
        }

        public string user_address
        {
            get { return _user_address; }
            set { _user_address = value; }
        }
        
        public string user_social_number
        {
            get { return _user_social_number; }
            set { _user_social_number = value; }
        }

        public string user_phone_number
        {
            get { return _user_phone_number; }
            set { _user_phone_number = value; }
        }


        public string user_id_card_file
        {
            get { return _user_id_card_file; }
            set { _user_id_card_file = value; }
        }

        public string user_photo_file
        {
            get { return _user_photo_file; }
            set { _user_photo_file = value; }
        }

        public string user_gender
        {
            get { return _user_gender; }
            set { _user_gender = value; }
        }

        public string user_marital_status
        {
            get { return _user_marital_status; }
            set { _user_marital_status = value; }
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

        public string user_group_name 
        {
            get { return _user_group_name; }
            set { _user_group_name = value; }
        }

        #endregion

        #region Method
        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<CUser> Login(string user_email, string user_password)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@user_email", SqlDbType.VarChar, 255, ParameterDirection.Input, user_email);
                AddParamToSQLCmd(sqlCmd, "@user_password", SqlDbType.VarChar, 255, ParameterDirection.Input, user_password);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_login_user");
                ExecuteScalarCmd(sqlCmd);

                List<CUser> UserList = new List<CUser>();
                TExecuteReaderCmd<CUser>(sqlCmd, TGenerateNewsListFromReader<CUser>, ref UserList);
                return UserList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CUser> GetUserByEmail(string user_name)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@user_name", SqlDbType.VarChar, 255, ParameterDirection.Input, user_name);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_user_by_username_or_user_email");
                ExecuteScalarCmd(sqlCmd);

                List<CUser> UserList = new List<CUser>();
                TExecuteReaderCmd<CUser>(sqlCmd, TGenerateNewsListFromReader<CUser>, ref UserList);
                return UserList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CUser> GetUserById(int user_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@user_id", SqlDbType.Int, 255, ParameterDirection.Input, user_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_user_by_id");
                ExecuteScalarCmd(sqlCmd);

                List<CUser> UserList = new List<CUser>();
                TExecuteReaderCmd<CUser>(sqlCmd, TGenerateNewsListFromReader<CUser>, ref UserList);
                return UserList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<CUser> GetUserAll(string user_name)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_user_all");
                ExecuteScalarCmd(sqlCmd);

                List<CUser> UserList = new List<CUser>();
                TExecuteReaderCmd<CUser>(sqlCmd, TGenerateNewsListFromReader<CUser>, ref UserList);
                return UserList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static void TGenerateNewsListFromReader<T>(SqlDataReader returnData, ref List<CUser> UserList)
        {
            try
            {
                while (returnData.Read())
                {
                    CUser user = new CUser();
                    if (returnData["user_id"] != DBNull.Value) user.user_id = Convert.ToInt32(returnData["user_id"]);
                    if (returnData["user_name"] != DBNull.Value) user.user_name = returnData["user_name"].ToString();
                    if (returnData["user_email"] != DBNull.Value) user.user_email = returnData["user_email"].ToString();
                    if (returnData["user_first_name"] != DBNull.Value) user.user_first_name = returnData["user_first_name"].ToString();
                    if (returnData["user_password"] != DBNull.Value) user.user_password = returnData["user_password"].ToString();

                    if (returnData["user_last_name"] != DBNull.Value) user.user_last_name = returnData["user_last_name"].ToString();
                    if (returnData["user_last_login"] != DBNull.Value) user.user_last_login = Convert.ToDateTime(returnData["user_last_login"].ToString());
                    if (returnData["user_group_id"] != DBNull.Value) user.user_group_id = Convert.ToInt32(returnData["user_group_id"].ToString());
                    if (returnData["user_birth_place"] != DBNull.Value) user.user_birth_place = returnData["user_birth_place"].ToString();
                    if (returnData["user_birth_date"] != DBNull.Value) user.user_birth_date = Convert.ToDateTime(returnData["user_birth_date"].ToString());
                    if (returnData["user_address"] != DBNull.Value) user.user_address = returnData["user_address"].ToString();
                    if (returnData["user_social_number"] != DBNull.Value) user.user_social_number = returnData["user_social_number"].ToString();
                    if (returnData["user_phone_number"] != DBNull.Value) user.user_phone_number = returnData["user_phone_number"].ToString();
                    if (returnData["user_id_card_file"] != DBNull.Value) user.user_id_card_file = returnData["user_id_card_file"].ToString();
                    if (returnData["user_photo_file"] != DBNull.Value) user.user_photo_file = returnData["user_photo_file"].ToString();
                    if (returnData["user_gender"] != DBNull.Value) user.user_gender = returnData["user_gender"].ToString();
                    if (returnData["user_marital_status"] != DBNull.Value) user.user_marital_status = returnData["user_marital_status"].ToString();
                    if (returnData["created_by"] != DBNull.Value) user.created_by = returnData["created_by"].ToString();
                    if (returnData["created_date"] != DBNull.Value) user.created_date = Convert.ToDateTime(returnData["created_date"].ToString());
                    if (returnData["updated_by"] != DBNull.Value) user.updated_by = returnData["updated_by"].ToString();
                    if (returnData["updated_date"] != DBNull.Value) user.updated_date = Convert.ToDateTime(returnData["updated_date"].ToString());


                    UserList.Add(user);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        private static void TGenerateObjFromReader<T>(SqlDataReader returnData, ref CUser user)
        {
            try
            {
                while (returnData.Read())
                {
                    if (returnData["user_id"] != DBNull.Value) user.user_id = Convert.ToInt32(returnData["user_id"]);
                    if (returnData["user_name"] != DBNull.Value) user.user_name = returnData["user_name"].ToString();
                    if (returnData["user_email"] != DBNull.Value) user.user_email = returnData["user_email"].ToString();
                    if (returnData["user_first_name"] != DBNull.Value) user.user_first_name = returnData["user_first_name"].ToString();
                    if (returnData["user_last_name"] != DBNull.Value) user.user_last_name = returnData["user_last_name"].ToString();
                    if (returnData["user_last_login"] != DBNull.Value) user.user_last_login = Convert.ToDateTime(returnData["user_last_login"].ToString());
                    if (returnData["user_group_id"] != DBNull.Value) user.user_group_id = Convert.ToInt32(returnData["user_group_id"].ToString());
                    if (returnData["user_birth_place"] != DBNull.Value) user.user_birth_place = returnData["user_birth_place"].ToString();
                    if (returnData["user_birth_date"] != DBNull.Value) user.user_birth_date = Convert.ToDateTime(returnData["user_birth_date"].ToString());
                    if (returnData["user_address"] != DBNull.Value) user.user_address = returnData["user_address"].ToString();
                    if (returnData["user_social_number"] != DBNull.Value) user.user_social_number = returnData["user_social_number"].ToString();
                    if (returnData["user_phone_number"] != DBNull.Value) user.user_phone_number = returnData["user_phone_number"].ToString();
                    if (returnData["user_id_card_file"] != DBNull.Value) user.user_id_card_file = returnData["user_id_card_file"].ToString();
                    if (returnData["user_photo_file"] != DBNull.Value) user.user_photo_file = returnData["user_photo_file"].ToString();
                    if (returnData["user_gender"] != DBNull.Value) user.user_gender = returnData["user_gender"].ToString();
                    if (returnData["user_marital_status"] != DBNull.Value) user.user_marital_status = returnData["user_marital_status"].ToString();
                    if (returnData["created_by"] != DBNull.Value) user.created_by = returnData["created_by"].ToString();
                    if (returnData["created_date"] != DBNull.Value) user.created_date = Convert.ToDateTime(returnData["created_date"].ToString());
                    if (returnData["updated_by"] != DBNull.Value) user.updated_by = returnData["updated_by"].ToString();
                    if (returnData["updated_date"] != DBNull.Value) user.updated_date = Convert.ToDateTime(returnData["updated_date"].ToString());
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
                AddParamToSQLCmd(sqlCmd, "@user_name", SqlDbType.VarChar, 50, ParameterDirection.Input, this.user_name);
                AddParamToSQLCmd(sqlCmd, "@user_email", SqlDbType.VarChar, 100, ParameterDirection.Input, this.user_email);
                AddParamToSQLCmd(sqlCmd, "@user_password", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_password);
                AddParamToSQLCmd(sqlCmd, "@user_first_name", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_first_name);
                AddParamToSQLCmd(sqlCmd, "@user_last_name", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_last_name);
                AddParamToSQLCmd(sqlCmd, "@user_last_login", SqlDbType.DateTime, 0, ParameterDirection.Input, this.user_last_login);
                AddParamToSQLCmd(sqlCmd, "@user_group_id", SqlDbType.Int, 0, ParameterDirection.Input, this.user_group_id);
                AddParamToSQLCmd(sqlCmd, "@user_birth_place", SqlDbType.VarChar,255, ParameterDirection.Input, this.user_birth_place);
                AddParamToSQLCmd(sqlCmd, "@user_birth_date", SqlDbType.DateTime, 0, ParameterDirection.Input, this.user_birth_date);
                AddParamToSQLCmd(sqlCmd, "@user_address", SqlDbType.Text, 0, ParameterDirection.Input, this.user_address);
                AddParamToSQLCmd(sqlCmd, "@user_social_number", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_social_number);
                AddParamToSQLCmd(sqlCmd, "@user_phone_number", SqlDbType.VarChar, 100, ParameterDirection.Input, this.user_phone_number);
                AddParamToSQLCmd(sqlCmd, "@user_id_card_file", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_phone_number);
                AddParamToSQLCmd(sqlCmd, "@user_photo_file", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_photo_file);
                AddParamToSQLCmd(sqlCmd, "@user_gender", SqlDbType.VarChar, 100, ParameterDirection.Input, this.user_gender);
                AddParamToSQLCmd(sqlCmd, "@user_marital_status", SqlDbType.VarChar, 100, ParameterDirection.Input, this.user_marital_status);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar,255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_user_insert");
                ExecuteScalarCmd(sqlCmd);

                this.user_id = Convert.ToInt32(sqlCmd.Parameters["@ReturnValue"].Value);
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

                AddParamToSQLCmd(sqlCmd, "@user_first_name", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_first_name);
                AddParamToSQLCmd(sqlCmd, "@user_last_name", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_last_name);
                AddParamToSQLCmd(sqlCmd, "@user_birth_place", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_birth_place);
                AddParamToSQLCmd(sqlCmd, "@user_birth_date", SqlDbType.DateTime, 0, ParameterDirection.Input, this.user_birth_date);
                AddParamToSQLCmd(sqlCmd, "@user_address", SqlDbType.Text, 0, ParameterDirection.Input, this.user_address);
                AddParamToSQLCmd(sqlCmd, "@user_social_number", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_social_number);
                AddParamToSQLCmd(sqlCmd, "@user_phone_number", SqlDbType.VarChar, 100, ParameterDirection.Input, this.user_phone_number);
                AddParamToSQLCmd(sqlCmd, "@user_id_card_file", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_phone_number);
                AddParamToSQLCmd(sqlCmd, "@user_photo_file", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_photo_file);
                AddParamToSQLCmd(sqlCmd, "@user_gender", SqlDbType.VarChar, 100, ParameterDirection.Input, this.user_gender);
                AddParamToSQLCmd(sqlCmd, "@user_marital_status", SqlDbType.VarChar, 100, ParameterDirection.Input, this.user_marital_status);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@user_id", SqlDbType.Int, 0, ParameterDirection.Input, this.user_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "spCT_CommunityUpdate");
                ExecuteScalarCmd(sqlCmd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void UpdateLastLogin()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                AddParamToSQLCmd(sqlCmd, "@user_last_login", SqlDbType.DateTime, 0, ParameterDirection.Input, this.user_last_login);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@user_id", SqlDbType.Decimal, 0, ParameterDirection.Input, this.user_id);
                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_user_update_last_login");
                ExecuteScalarCmd(sqlCmd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void UpdatePassword()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                AddParamToSQLCmd(sqlCmd, "@user_password", SqlDbType.VarChar, 255, ParameterDirection.Input, this.user_password);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@user_id", SqlDbType.Decimal, 0, ParameterDirection.Input, this.user_id);
                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_user_update_password");
                ExecuteScalarCmd(sqlCmd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void UpdateGroup()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                AddParamToSQLCmd(sqlCmd, "@user_group_id", SqlDbType.Int, 0, ParameterDirection.Input, this.user_group_id);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@user_id", SqlDbType.Decimal, 0, ParameterDirection.Input, this.user_id);
                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_user_delete");
                ExecuteScalarCmd(sqlCmd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Delete(int user_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                AddParamToSQLCmd(sqlCmd, "@user_id", SqlDbType.Decimal, 0, ParameterDirection.Input, this.user_id);
                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_user_delete");
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