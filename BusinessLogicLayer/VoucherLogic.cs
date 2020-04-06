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
   public class VoucherLogic : ILogic<Voucher>
    {
        public int Insert(Voucher obj)
        {
            string query = "Insert into Voucher (CustomerID, Date, Amount, Remark, VoucherNumber) values(@CustomerID, @Date, @Amount, @Remark, @VoucherNumber)";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            param.Add(new SqlParameter("@Date", obj.Date));
            param.Add(new SqlParameter("@Amount", obj.Amount));
            param.Add(new SqlParameter("@Remark", obj.Remark));
            param.Add(new SqlParameter("@VoucherNumber", obj.VoucherNumber));
            return DataAccess.NonQuery(query, param);
        }

        public Voucher SelectByID(int VoucherID)
        {
            string query = "Select * from Voucher where VoucherID = @VoucherID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@VoucherID", VoucherID));

            DataTable dt = DataAccess.SelectData(query, param);
            if (dt.Rows.Count == 1)
            {
                Voucher objMember = new Voucher();
                objMember.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                objMember.Date = Convert.ToDateTime(dt.Rows[0]["Date"].ToString());
                objMember.Remark = dt.Rows[0]["Remark"].ToString();
                objMember.Amount = Convert.ToDouble(dt.Rows[0]["Amount"].ToString());
                objMember.VoucherNumber = dt.Rows[0]["VoucherNumber"].ToString();
                return objMember;
            }
            else
            {
                return new Voucher();
            }
        }

        public int Update(Voucher obj)
        {
            string query = "UPDATE Voucher Set CustomerID = @CustomerID, Date=@Date, Remark=@Remark, Amount=@Amount, VoucherNumber=@VoucherNumber  WHERE VoucherID = @VoucherID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@VoucherID", obj.VoucherID));
            param.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            param.Add(new SqlParameter("@Date", obj.Date));
            param.Add(new SqlParameter("@Remark", obj.Remark));
            param.Add(new SqlParameter("@Amount", obj.Amount));
            param.Add(new SqlParameter("@VoucherNumber", obj.VoucherNumber));
            return DataAccess.NonQuery(query, param);
        }

        public int Delete(int ID)
        {
            string query = "delete Voucher where VoucherID = @VoucherID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@VoucherID", ID));

            return DataAccess.NonQuery(query, param);
        }

        public DataTable SelectAll()
        {
            return DataAccess.SelectData("select * from Voucher", new List<SqlParameter>());
        }

        public List<Voucher> SelectList()
        {
            DataTable dt = DataAccess.SelectData("select * from Voucher", new List<SqlParameter>());
            List<Voucher> productList = new List<Voucher>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Voucher objMember = new Voucher();
                objMember.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                objMember.Date = Convert.ToDateTime(dt.Rows[0]["Date"].ToString());
                objMember.Remark = dt.Rows[0]["Remark"].ToString();
                objMember.Amount = Convert.ToDouble(dt.Rows[0]["Amount"].ToString());
                objMember.VoucherNumber = dt.Rows[0]["VoucherNumber"].ToString();
                productList.Add(objMember);
            }

            return productList;
        }



        public DataTable SelectWithOrgName()
        {
            string qry = "select v.*,c.Organization,c.CustomerName from Voucher as v Inner Join Customer as c ON v.CustomerID = c.CustomerID order by v.Date DESC";
            return DataAccess.SelectData(qry, new List<SqlParameter>());   
        }
    }
}
