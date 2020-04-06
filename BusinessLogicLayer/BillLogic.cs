using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogicLayer
{
    public class BillLogic : ILogic<Bill>
    {
        public int Insert(Bill obj)
        {
            string query = "Insert into Bill(BillNumber, CustomerID, CreatedOn, TotalAmount, Remark) values(@BillNumber, @CustomerID, @CreatedOn, @TotalAmount, @Remark)";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@BillNumber", obj.BillNumber));
            param.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            param.Add(new SqlParameter("@CreatedOn", obj.CreatedOn));
            param.Add(new SqlParameter("@TotalAmount", obj.TotalAmount));
            param.Add(new SqlParameter("@Remark", obj.Remark));

          
            return DataAccess.NonQuery(query, param);
        }

        public Bill SelectByID(int BillID)
        {
            string query = "Select * from Bill where BillID = @BillID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@BillID", BillID));

            DataTable dt = DataAccess.SelectData(query, param);
            if (dt.Rows.Count == 1)
            {
                Bill objMember = new Bill();
                objMember.BillNumber = dt.Rows[0]["BillNumber"].ToString();
                objMember.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                objMember.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"].ToString());
                objMember.TotalAmount = Convert.ToDouble(dt.Rows[0]["TotalAmount"].ToString());
                objMember.Remark = dt.Rows[0]["Remark"].ToString();

                return objMember;
            }
            else
            {
                return new Bill();
            }
        }

        public int Update(Bill obj)
        {
            string query = "UPDATE Bill Set BillNumber= @BillNumber, CustomerID= @CustomerID, CreatedOn = @CreatedOn, TotalAmount= @TotalAmount, Remark= @Remark WHERE BillID = @BillID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@BillID", obj.BillID));
            param.Add(new SqlParameter("@BillNumber", obj.BillNumber));
            param.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            param.Add(new SqlParameter("@CreatedOn", obj.CreatedOn));
            param.Add(new SqlParameter("@TotalAmount", obj.TotalAmount));
            param.Add(new SqlParameter("@Remark", obj.Remark));

            return DataAccess.NonQuery(query, param);
        }

        public int Delete(int ID)
        {
            string query = "delete Bill where BillID = @BillID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@BillID", ID));

            return DataAccess.NonQuery(query, param);
        }

        public DataTable SelectAll()
        {
            return DataAccess.SelectData("select * from Bill order by CreatedOn DESC", new List<SqlParameter>());
        }

        public List<Bill> SelectList()
        {
            DataTable dt = DataAccess.SelectData("select * from Bill", new List<SqlParameter>());
            List<Bill> billlist = new List<Bill>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Bill objMember = new Bill();
                objMember.BillNumber = dt.Rows[0]["BillNumber"].ToString();
                objMember.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                objMember.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"].ToString());
                objMember.TotalAmount = Convert.ToDouble(dt.Rows[0]["TotalAmount"].ToString());
                objMember.Remark = dt.Rows[0]["Remark"].ToString();

                billlist.Add(objMember);
            }

            return billlist;
        }




        public int getCurrentIdentity()
        {
            
            DataTable dt = DataAccess.SelectData("SELECT IDENT_CURRENT('Bill') as curID", new List<SqlParameter>());
            return Convert.ToInt32(dt.Rows[0]["curID"].ToString());
        }



        public DataTable SelectFilter(int cusID,string stDate, string endDate)
        {
            
            string qry = "select * from Bill where CreatedOn between @stDate and  @EndDate AND CustomerID = @cusID"; 
            List<SqlParameter> prams = new List<SqlParameter>();
            prams.Add(new SqlParameter("@stDate", stDate));
            prams.Add(new SqlParameter("@EndDate", endDate));
            prams.Add(new SqlParameter("@cusID",cusID ));
            return DataAccess.SelectData(qry, prams);
        }

        public DataTable SelectFilterByCustomer(int p)
        {
            string qry = "select * from Bill where CustomerID = @cusID";
            List<SqlParameter> prams = new List<SqlParameter>();
            prams.Add(new SqlParameter("@cusID", p));
            return DataAccess.SelectData(qry, prams);
        }

        public DataTable SelectFilterForVoucher(int p, string stdt, string eddt)
        {
            string qry = "select v.*,c.* from Voucher as v Inner Join Customer as c ON v.CustomerID = c.CustomerID where v.Date between @stDate and  @EndDate AND v.CustomerID = @cusID";
            List<SqlParameter> prams = new List<SqlParameter>();
            prams.Add(new SqlParameter("@stDate", stdt));
            prams.Add(new SqlParameter("@EndDate", eddt));
            prams.Add(new SqlParameter("@cusID", p));
            return DataAccess.SelectData(qry, prams);
        }

        public DataTable SelectFilterByCustomerForVoucher(int p)
        {
            string qry = "select v.*,c.* from Voucher as v Inner Join Customer as c ON v.CustomerID = c.CustomerID  where v.CustomerID = @cusID";
            List<SqlParameter> prams = new List<SqlParameter>();
            prams.Add(new SqlParameter("@cusID", p));
            return DataAccess.SelectData(qry, prams);
        }
    }
}
