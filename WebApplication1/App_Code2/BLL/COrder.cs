
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
    public class COrder : DataAccessHelper
    {
        #region Variables
        private int _order_id;
        private string _full_name;
        private string _address;
        private string _zip_code;
        private string _area;
        private string _country;
        private string _phone;
        private string _mobile_phone;
        private string _id_card_number;
        private DateTime _birth_date;
        private decimal _height;
        private decimal _weight;
        private string _gender;
        private string _marriage_status;
        private int _haji;
        private string _pewaris_name;
        private string _pewaris_id_card_number;
        private string _pewaris_relation;
        private string _pewaris_gender;
        private string _pewaris_phone;
        private string _pewaris_payment_for;
        private decimal _money;
        private string _check_number;
        private string _order_name;
        private DateTime _order_tarikh;
        private string _order_kp_number;
        private string _wakil_name;
        private DateTime _wakil_tarikh;
        private string _wakil_code;
        private string _created_by;
        private DateTime _created_date;
        private string _updated_by;
        private DateTime _updated_date;
        private string _user_group_name;


        #endregion

        #region Constructor
        public COrder()
        {
        }

        public COrder(int order_id)
        {
            List<COrder> orderList = new List<COrder>();
            orderList = GetOrderById(order_id);
            foreach (COrder oObj in orderList)
            {
                this.order_id = oObj.order_id;
                this.full_name = oObj.full_name;
                this.address = oObj.address;
                this.zip_code = oObj.zip_code;
                this.area = oObj.area;
                this.country = oObj.country;
                this.phone = oObj.phone;
                this.mobile_phone = oObj.mobile_phone;
                this.id_card_number = oObj.id_card_number;
                this.birth_date = oObj.birth_date;
                this.height = oObj.height;
                this.weight = oObj.weight;
                this.gender = oObj.gender;
                this.marriage_status = oObj.marriage_status;
                this.haji = oObj.haji;
                this.pewaris_name = oObj.pewaris_name;
                this.pewaris_id_card_number = oObj.pewaris_id_card_number;
                this.pewaris_relation = oObj.pewaris_relation;
                this.pewaris_gender = oObj.pewaris_gender;
                this.pewaris_phone = oObj.pewaris_phone;
                this.pewaris_payment_for = oObj.pewaris_payment_for;
                this.money = oObj.money;
                this.check_number = oObj.check_number;
                this.order_name = oObj.order_name;
                this.order_tarikh = oObj.order_tarikh;
                this.order_kp_number = oObj.order_kp_number;
                this.wakil_name = oObj.wakil_name;
                this.wakil_tarikh = oObj.wakil_tarikh;
                this.wakil_code = oObj.wakil_code;
                this.created_by = oObj.created_by;
                this.created_date = oObj.created_date;
                this.updated_by = oObj.updated_by;
                this.updated_date = oObj.updated_date;
            }
        }
        #endregion

        #region Properties
        public int order_id
        {
            get { return _order_id; }
            set { _order_id = value; }
        }

        public string full_name
        {
            get { return _full_name; }
            set { _full_name = value; }
        }

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string zip_code
        {
            get { return _zip_code; }
            set { _zip_code = value; }
        }

        public string area
        {
            get { return _area; }
            set { _area = value; }
        }

        public string country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string mobile_phone
        {
            get { return _mobile_phone; }
            set { _mobile_phone = value; }
        }

        public string id_card_number
        {
            get { return _id_card_number; }
            set { _id_card_number = value; }
        }

        public DateTime birth_date
        {
            get { return _birth_date; }
            set { _birth_date = value; }
        }

        public decimal height
        {
            get { return _height; }
            set { _height = value; }
        }

        public decimal weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }


        public string marriage_status
        {
            get { return _marriage_status; }
            set { _marriage_status = value; }
        }

        public int haji
        {
            get { return _haji; }
            set { _haji = value; }
        }

        public string pewaris_name
        {
            get { return _pewaris_name; }
            set { _pewaris_name = value; }
        }

        public string pewaris_id_card_number
        {
            get { return _pewaris_id_card_number; }
            set { _pewaris_id_card_number = value; }
        }

        public string pewaris_relation
        {
            get { return _pewaris_relation; }
            set { _pewaris_relation = value; }
        }

        public string pewaris_gender
        {
            get { return _pewaris_gender; }
            set { _pewaris_gender = value; }
        }

        public string pewaris_phone
        {
            get { return _pewaris_phone; }
            set { _pewaris_phone = value; }
        }

        public string pewaris_payment_for
        {
            get { return _pewaris_payment_for; }
            set { _pewaris_payment_for = value; }
        }

        public decimal money
        {
            get { return _money; }
            set { _money = value; }
        }

        public string check_number
        {
            get { return _check_number; }
            set { _check_number = value; }
        }

        public string order_name
        {
            get { return _order_name; }
            set { _order_name = value; }
        }

        public DateTime order_tarikh
        {
            get { return _order_tarikh; }
            set { _order_tarikh = value; }
        }

        public string order_kp_number
        {
            get { return _order_kp_number; }
            set { _order_kp_number = value; }
        }

        public string wakil_name
        {
            get { return _wakil_name; }
            set { _wakil_name = value; }
        }

        public DateTime wakil_tarikh
        {
            get { return _wakil_tarikh; }
            set { _wakil_tarikh = value; }
        }

        public string wakil_code
        {
            get { return _wakil_code; }
            set { _wakil_code = value; }
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

        public List<COrder> GetReport1(DateTime start_from, DateTime end_to)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@start_from", SqlDbType.DateTime, 0, ParameterDirection.Input, start_from);
                AddParamToSQLCmd(sqlCmd, "@end_to", SqlDbType.DateTime, 0, ParameterDirection.Input, end_to);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_order_report_1");
                ExecuteScalarCmd(sqlCmd);

                List<COrder> orderList = new List<COrder>();
                TExecuteReaderCmd<COrder>(sqlCmd, TGenerateNewsListFromReader<COrder>, ref orderList);
                return orderList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public List<COrder> GetOrderById(int order_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();

                AddParamToSQLCmd(sqlCmd, "@order_id", SqlDbType.Int, 255, ParameterDirection.Input, order_id);

                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_order_by_id");
                ExecuteScalarCmd(sqlCmd);

                List<COrder> orderList = new List<COrder>();
                TExecuteReaderCmd<COrder>(sqlCmd, TGenerateNewsListFromReader<COrder>, ref orderList);
                return orderList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<COrder> GetOrderAll()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_get_order_all");
                ExecuteScalarCmd(sqlCmd);

                List<COrder> orderList = new List<COrder>();
                TExecuteReaderCmd<COrder>(sqlCmd, TGenerateNewsListFromReader<COrder>, ref orderList);
                return orderList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private static void TGenerateNewsListFromReader<T>(SqlDataReader returnData, ref List<COrder> orderList)
        {
            try
            {
                while (returnData.Read())
                {
                    COrder oObj = new COrder();
                    if (returnData["order_id"] != DBNull.Value) oObj.order_id = Convert.ToInt32(returnData["order_id"]);
                    if (returnData["full_name"] != DBNull.Value) oObj.full_name = returnData["full_name"].ToString();
                    if (returnData["address"] != DBNull.Value) oObj.address = returnData["address"].ToString();
                    if (returnData["zip_code"] != DBNull.Value) oObj.zip_code = returnData["zip_code"].ToString();
                    if (returnData["area"] != DBNull.Value) oObj.area = returnData["area"].ToString();
                    if (returnData["country"] != DBNull.Value) oObj.country = returnData["country"].ToString();
                    if (returnData["phone"] != DBNull.Value) oObj.phone = returnData["phone"].ToString();
                    if (returnData["mobile_phone"] != DBNull.Value) oObj.mobile_phone = returnData["mobile_phone"].ToString();
                    if (returnData["id_card_number"] != DBNull.Value) oObj.id_card_number = returnData["id_card_number"].ToString();
                    if (returnData["birth_date"] != DBNull.Value) oObj.birth_date = Convert.ToDateTime(returnData["birth_date"].ToString());
                    if (returnData["height"] != DBNull.Value) oObj.height = Convert.ToDecimal(returnData["height"].ToString());
                    if (returnData["weight"] != DBNull.Value) oObj.weight = Convert.ToDecimal(returnData["weight"].ToString());
                    if (returnData["gender"] != DBNull.Value) oObj.gender = returnData["gender"].ToString();
                    if (returnData["marriage_status"] != DBNull.Value) oObj.marriage_status = returnData["marriage_status"].ToString();
                    if (returnData["haji"] != DBNull.Value) oObj.haji = Convert.ToInt32(returnData["haji"].ToString());
                    if (returnData["pewaris_name"] != DBNull.Value) oObj.pewaris_name = returnData["pewaris_name"].ToString();
                    if (returnData["pewaris_id_card_number"] != DBNull.Value) oObj.pewaris_id_card_number = returnData["pewaris_id_card_number"].ToString();
                    if (returnData["pewaris_relation"] != DBNull.Value) oObj.pewaris_relation = returnData["pewaris_relation"].ToString();
                    if (returnData["pewaris_gender"] != DBNull.Value) oObj.pewaris_gender = returnData["pewaris_gender"].ToString();
                    if (returnData["pewaris_phone"] != DBNull.Value) oObj.pewaris_phone = returnData["pewaris_phone"].ToString();
                    if (returnData["pewaris_payment_for"] != DBNull.Value) oObj.pewaris_payment_for = returnData["pewaris_payment_for"].ToString();
                    if (returnData["order_money"] != DBNull.Value) oObj.money = Convert.ToDecimal(returnData["order_money"].ToString());
                    if (returnData["check_number"] != DBNull.Value) oObj.check_number = returnData["check_number"].ToString();
                    if (returnData["order_name"] != DBNull.Value) oObj.order_name = returnData["order_name"].ToString();
                    if (returnData["order_tarikh"] != DBNull.Value) oObj.order_tarikh = Convert.ToDateTime(returnData["order_tarikh"].ToString());
                    if (returnData["order_kp_number"] != DBNull.Value) oObj.order_kp_number = returnData["order_kp_number"].ToString();
                    if (returnData["wakil_name"] != DBNull.Value) oObj.wakil_name = returnData["wakil_name"].ToString();
                    if (returnData["wakil_tarikh"] != DBNull.Value) oObj.wakil_tarikh = Convert.ToDateTime(returnData["wakil_tarikh"].ToString());
                    if (returnData["wakil_code"] != DBNull.Value) oObj.wakil_code = returnData["wakil_code"].ToString();
                    if (returnData["created_by"] != DBNull.Value) oObj.created_by = returnData["created_by"].ToString();
                    if (returnData["created_date"] != DBNull.Value) oObj.created_date = Convert.ToDateTime(returnData["created_date"].ToString());
                    if (returnData["updated_by"] != DBNull.Value) oObj.updated_by = returnData["updated_by"].ToString();
                    if (returnData["updated_date"] != DBNull.Value) oObj.updated_date = Convert.ToDateTime(returnData["updated_date"].ToString());


                    orderList.Add(oObj);
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
                    COrder oObj = new COrder();
                    if (returnData["order_id"] != DBNull.Value) oObj.order_id = Convert.ToInt32(returnData["order_id"]);
                    if (returnData["full_name"] != DBNull.Value) oObj.full_name = returnData["full_name"].ToString();
                    if (returnData["address"] != DBNull.Value) oObj.address = returnData["address"].ToString();
                    if (returnData["zip_code"] != DBNull.Value) oObj.zip_code = returnData["zip_code"].ToString();
                    if (returnData["area"] != DBNull.Value) oObj.area = returnData["area"].ToString();
                    if (returnData["country"] != DBNull.Value) oObj.country = returnData["country"].ToString();
                    if (returnData["phone"] != DBNull.Value) oObj.phone = returnData["phone"].ToString();
                    if (returnData["mobile_phone"] != DBNull.Value) oObj.mobile_phone = returnData["mobile_phone"].ToString();
                    if (returnData["id_card_number"] != DBNull.Value) oObj.id_card_number = returnData["id_card_number"].ToString();
                    if (returnData["birth_date"] != DBNull.Value) oObj.birth_date = Convert.ToDateTime(returnData["birth_date"].ToString());
                    if (returnData["height"] != DBNull.Value) oObj.height = Convert.ToDecimal(returnData["height"].ToString());
                    if (returnData["weight"] != DBNull.Value) oObj.weight = Convert.ToDecimal(returnData["weight"].ToString());
                    if (returnData["gender"] != DBNull.Value) oObj.gender = returnData["gender"].ToString();
                    if (returnData["marriage_status"] != DBNull.Value) oObj.marriage_status = returnData["marriage_status"].ToString();
                    if (returnData["haji"] != DBNull.Value) oObj.haji = Convert.ToInt32(returnData["haji"].ToString());
                    if (returnData["pewaris_name"] != DBNull.Value) oObj.pewaris_name = returnData["pewaris_name"].ToString();
                    if (returnData["pewaris_id_card_number"] != DBNull.Value) oObj.pewaris_id_card_number = returnData["pewaris_id_card_number"].ToString();
                    if (returnData["pewaris_relation"] != DBNull.Value) oObj.pewaris_relation = returnData["pewaris_relation"].ToString();
                    if (returnData["pewaris_gender"] != DBNull.Value) oObj.pewaris_gender = returnData["pewaris_gender"].ToString();
                    if (returnData["pewaris_phone"] != DBNull.Value) oObj.pewaris_phone = returnData["pewaris_phone"].ToString();
                    if (returnData["pewaris_payment_for"] != DBNull.Value) oObj.pewaris_payment_for = returnData["pewaris_payment_for"].ToString();
                    if (returnData["order_money"] != DBNull.Value) oObj.money = Convert.ToDecimal(returnData["order_money"].ToString());
                    if (returnData["check_number"] != DBNull.Value) oObj.check_number = returnData["check_number"].ToString();
                    if (returnData["order_name"] != DBNull.Value) oObj.order_name = returnData["order_name"].ToString();
                    if (returnData["order_tarikh"] != DBNull.Value) oObj.order_tarikh = Convert.ToDateTime(returnData["order_tarikh"].ToString());
                    if (returnData["order_kp_number"] != DBNull.Value) oObj.order_kp_number = returnData["order_kp_number"].ToString();
                    if (returnData["wakil_name"] != DBNull.Value) oObj.wakil_name = returnData["wakil_name"].ToString();
                    if (returnData["wakil_tarikh"] != DBNull.Value) oObj.wakil_tarikh = Convert.ToDateTime(returnData["wakil_tarikh"].ToString());
                    if (returnData["wakil_code"] != DBNull.Value) oObj.wakil_code = returnData["wakil_code"].ToString();
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
                AddParamToSQLCmd(sqlCmd, "@full_name", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.full_name);
                AddParamToSQLCmd(sqlCmd, "@address", SqlDbType.Text, 0, ParameterDirection.Input, this.address);
                AddParamToSQLCmd(sqlCmd, "@zip_code", SqlDbType.VarChar, 10, ParameterDirection.Input, this.zip_code);
                AddParamToSQLCmd(sqlCmd, "@area", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.area);
                AddParamToSQLCmd(sqlCmd, "@country", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.country);
                AddParamToSQLCmd(sqlCmd, "@phone", SqlDbType.VarChar, 100, ParameterDirection.Input, this.phone);
                AddParamToSQLCmd(sqlCmd, "@mobile_phone", SqlDbType.VarChar, 100, ParameterDirection.Input, this.mobile_phone);
                AddParamToSQLCmd(sqlCmd, "@id_card_number", SqlDbType.VarChar, 255, ParameterDirection.Input, this.id_card_number);
                AddParamToSQLCmd(sqlCmd, "@birth_date", SqlDbType.DateTime, 0, ParameterDirection.Input, this.birth_date);
                AddParamToSQLCmd(sqlCmd, "@height", SqlDbType.Decimal, 0, ParameterDirection.Input, this.height);
                AddParamToSQLCmd(sqlCmd, "@weight", SqlDbType.Decimal, 0, ParameterDirection.Input, this.weight);
                AddParamToSQLCmd(sqlCmd, "@gender", SqlDbType.VarChar, 50, ParameterDirection.Input, this.gender);
                AddParamToSQLCmd(sqlCmd, "@marriage_status", SqlDbType.VarChar, 50, ParameterDirection.Input, this.marriage_status);
                AddParamToSQLCmd(sqlCmd, "@haji", SqlDbType.VarChar, 255, ParameterDirection.Input, this.haji);
                AddParamToSQLCmd(sqlCmd, "@pewaris_name", SqlDbType.VarChar, 100, ParameterDirection.Input, this.pewaris_name);
                AddParamToSQLCmd(sqlCmd, "@pewaris_id_card_number", SqlDbType.VarChar, 100, ParameterDirection.Input, this.pewaris_id_card_number);
                AddParamToSQLCmd(sqlCmd, "@pewaris_relation", SqlDbType.VarChar, 100, ParameterDirection.Input, this.pewaris_relation);
                AddParamToSQLCmd(sqlCmd, "@pewaris_gender", SqlDbType.VarChar, 100, ParameterDirection.Input, this.pewaris_gender);
                AddParamToSQLCmd(sqlCmd, "@pewaris_phone", SqlDbType.VarChar, 100, ParameterDirection.Input, this.pewaris_phone);
                AddParamToSQLCmd(sqlCmd, "@pewaris_payment_for", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.pewaris_payment_for);
                AddParamToSQLCmd(sqlCmd, "@money", SqlDbType.Decimal, 0, ParameterDirection.Input, this.money);
                AddParamToSQLCmd(sqlCmd, "@check_number", SqlDbType.VarChar, 50, ParameterDirection.Input, this.check_number);
                AddParamToSQLCmd(sqlCmd, "@order_name", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.order_name);
                AddParamToSQLCmd(sqlCmd, "@order_tarikh", SqlDbType.DateTime, 0, ParameterDirection.Input, this.order_tarikh);
                AddParamToSQLCmd(sqlCmd, "@order_kp_number", SqlDbType.VarChar, 100, ParameterDirection.Input, this.order_kp_number);
                AddParamToSQLCmd(sqlCmd, "@wakil_name", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.wakil_name);
                AddParamToSQLCmd(sqlCmd, "@wakil_tarikh", SqlDbType.DateTime, 0, ParameterDirection.Input, this.wakil_tarikh);
                AddParamToSQLCmd(sqlCmd, "@wakil_code", SqlDbType.VarChar, 100, ParameterDirection.Input, this.wakil_code);
                AddParamToSQLCmd(sqlCmd, "@created_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.created_by);
                AddParamToSQLCmd(sqlCmd, "@created_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_order_insert");
                ExecuteScalarCmd(sqlCmd);

                this.order_id = Convert.ToInt32(sqlCmd.Parameters["@ReturnValue"].Value);
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

                AddParamToSQLCmd(sqlCmd, "@full_name", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.full_name);
                AddParamToSQLCmd(sqlCmd, "@address", SqlDbType.Text, 0, ParameterDirection.Input, this.address);
                AddParamToSQLCmd(sqlCmd, "@zip_code", SqlDbType.VarChar, 10, ParameterDirection.Input, this.zip_code);
                AddParamToSQLCmd(sqlCmd, "@area", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.area);
                AddParamToSQLCmd(sqlCmd, "@country", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.country);
                AddParamToSQLCmd(sqlCmd, "@phone", SqlDbType.VarChar, 100, ParameterDirection.Input, this.phone);
                AddParamToSQLCmd(sqlCmd, "@mobile_phone", SqlDbType.VarChar, 100, ParameterDirection.Input, this.mobile_phone);
                AddParamToSQLCmd(sqlCmd, "@id_card_number", SqlDbType.VarChar, 255, ParameterDirection.Input, this.id_card_number);
                AddParamToSQLCmd(sqlCmd, "@birth_date", SqlDbType.DateTime, 0, ParameterDirection.Input, this.birth_date);
                AddParamToSQLCmd(sqlCmd, "@height", SqlDbType.Decimal, 0, ParameterDirection.Input, this.height);
                AddParamToSQLCmd(sqlCmd, "@weight", SqlDbType.Decimal, 0, ParameterDirection.Input, this.weight);
                AddParamToSQLCmd(sqlCmd, "@gender", SqlDbType.VarChar, 50, ParameterDirection.Input, this.gender);
                AddParamToSQLCmd(sqlCmd, "@marriage_status", SqlDbType.VarChar, 50, ParameterDirection.Input, this.marriage_status);
                AddParamToSQLCmd(sqlCmd, "@haji", SqlDbType.VarChar, 255, ParameterDirection.Input, this.haji);
                AddParamToSQLCmd(sqlCmd, "@pewaris_name", SqlDbType.VarChar, 100, ParameterDirection.Input, this.pewaris_name);
                AddParamToSQLCmd(sqlCmd, "@pewaris_id_card_number", SqlDbType.VarChar, 100, ParameterDirection.Input, this.pewaris_id_card_number);
                AddParamToSQLCmd(sqlCmd, "@pewaris_relation", SqlDbType.VarChar, 100, ParameterDirection.Input, this.pewaris_relation);
                AddParamToSQLCmd(sqlCmd, "@pewaris_gender", SqlDbType.VarChar, 100, ParameterDirection.Input, this.pewaris_gender);
                AddParamToSQLCmd(sqlCmd, "@pewaris_phone", SqlDbType.VarChar, 100, ParameterDirection.Input, this.pewaris_phone);
                AddParamToSQLCmd(sqlCmd, "@pewaris_payment_for", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.pewaris_payment_for);
                AddParamToSQLCmd(sqlCmd, "@money", SqlDbType.Decimal, 0, ParameterDirection.Input, this.money);
                AddParamToSQLCmd(sqlCmd, "@check_number", SqlDbType.VarChar, 50, ParameterDirection.Input, this.check_number);
                AddParamToSQLCmd(sqlCmd, "@order_name", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.order_name);
                AddParamToSQLCmd(sqlCmd, "@order_tarikh", SqlDbType.DateTime, 0, ParameterDirection.Input, this.order_tarikh);
                AddParamToSQLCmd(sqlCmd, "@order_kp_number", SqlDbType.VarChar, 100, ParameterDirection.Input, this.order_kp_number);
                AddParamToSQLCmd(sqlCmd, "@wakil_name", SqlDbType.VarChar, 8000, ParameterDirection.Input, this.wakil_name);
                AddParamToSQLCmd(sqlCmd, "@wakil_tarikh", SqlDbType.DateTime, 0, ParameterDirection.Input, this.wakil_tarikh);
                AddParamToSQLCmd(sqlCmd, "@wakil_code", SqlDbType.VarChar, 100, ParameterDirection.Input, this.wakil_code);
                AddParamToSQLCmd(sqlCmd, "@updated_by", SqlDbType.VarChar, 255, ParameterDirection.Input, this.updated_by);
                AddParamToSQLCmd(sqlCmd, "@updated_date", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now);
                AddParamToSQLCmd(sqlCmd, "@order_id", SqlDbType.Int, 0, ParameterDirection.Input, this.order_id);


                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_order_update");
                ExecuteScalarCmd(sqlCmd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Delete(int order_id)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                AddParamToSQLCmd(sqlCmd, "@order_id", SqlDbType.Int, 0, ParameterDirection.Input, order_id);
                SetCommandType(sqlCmd, CommandType.StoredProcedure, "sp_order_delete");
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