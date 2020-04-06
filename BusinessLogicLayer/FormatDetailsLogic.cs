using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class FormatDetailsLogic : ILogic<FormatDetails>
    {
        public int Insert(FormatDetails obj)
        {
            string query = "Insert into FormatDetails(FormatText, FormatFor, Counter) values(@FormatText, @FormatFor, @Counter)";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@FormatText", obj.FormatText));
            param.Add(new SqlParameter("@FormatFor", obj.FormatFor));
            param.Add(new SqlParameter("@Counter", obj.Counter));
            

            return DataAccess.NonQuery(query, param);
        }

        public FormatDetails SelectByID(int fdID)
        {
            string query = "Select * from FormatDetails where FormatID = @fdID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@fdID", fdID));

            DataTable dt = DataAccess.SelectData(query, param);
            if (dt.Rows.Count == 1)
            {
                FormatDetails objMember = new FormatDetails();
                objMember.FormatText = dt.Rows[0]["FormatText"].ToString();
                objMember.FormatFor = dt.Rows[0]["FormatFor"].ToString();
                objMember.Counter = Convert.ToInt32(dt.Rows[0]["Counter"].ToString());

                return objMember;
            }
            else
            {
                return new FormatDetails();
            }
        }

        public int Update(FormatDetails obj)
        {
            string query = "UPDATE FormatDetails Set FormatText = @FormatText, FormatFor = @FormatFor, Counter = @Counter WHERE FormatID=@FormatID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@FormatID", obj.FormatID));
            param.Add(new SqlParameter("@FormatText", obj.FormatText));
            param.Add(new SqlParameter("@FormatFor", obj.FormatFor));
            param.Add(new SqlParameter("@Counter", obj.Counter));            

            return DataAccess.NonQuery(query, param);
        }

        public int Delete(int ID)
        {
            string query = "delete FormatDetails where FormatID = @FormatID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@FormatID", ID));

            return DataAccess.NonQuery(query, param);
        }

        public DataTable SelectAll()
        {
            return DataAccess.SelectData("select * from FormatDetails", new List<SqlParameter>());
        }

        public List<FormatDetails> SelectList()
        {
            DataTable dt = DataAccess.SelectData("select * from FormatDetails", new List<SqlParameter>());
            List<FormatDetails> fdList = new List<FormatDetails>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FormatDetails objMember = new FormatDetails();
                objMember.FormatText = dt.Rows[0]["FormatText"].ToString();
                objMember.FormatFor = dt.Rows[0]["FormatFor"].ToString();
                objMember.Counter = Convert.ToInt32(dt.Rows[0]["Counter"].ToString());

                fdList.Add(objMember);
            }

            return fdList;
        }

        public FormatDetails SelectByType(string p)
        {
            string query = "Select * from FormatDetails where FormatFor = @fdType";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@fdType", p));

            DataTable dt = DataAccess.SelectData(query, param);
            if (dt.Rows.Count == 1)
            {
                FormatDetails objMember = new FormatDetails();
                objMember.FormatID = Convert.ToInt32(dt.Rows[0]["FormatID"].ToString());
                objMember.FormatText = dt.Rows[0]["FormatText"].ToString();
                objMember.FormatFor = dt.Rows[0]["FormatFor"].ToString();
                objMember.Counter = Convert.ToInt32(dt.Rows[0]["Counter"].ToString());

                return objMember;
            }
            else
            {
                return new FormatDetails();
            }
        }

        public string SelectBillSeq()
        {
            string qry = "select FormatText from FormatDetails where FormatFor='Bill'";
            DataTable dt = DataAccess.SelectData(qry, new List<SqlParameter>());
            string billFormat = null;
            if (dt.Rows.Count == 1)
            {
                
                billFormat = dt.Rows[0]["FormatText"].ToString();
            }
            return billFormat;
        }

        public string SelectVoucherSeq()
        {
            string qry = "select FormatText from FormatDetails where FormatFor='Voucher'";
            DataTable dt = DataAccess.SelectData(qry, new List<SqlParameter>());
            string billFormat = null;
            if (dt.Rows.Count == 1)
            {
                
                billFormat = dt.Rows[0]["FormatText"].ToString();
            }
            return billFormat;
        }

        public int getCurrentIdentity()
        {
            DataTable dt = DataAccess.SelectData("SELECT IDENT_CURRENT('Voucher') as curID", new List<SqlParameter>());
            return Convert.ToInt32(dt.Rows[0]["curID"].ToString());
        }
    }
}
