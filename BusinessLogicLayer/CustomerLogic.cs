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
    public class CustomerLogic : ILogic<Customer>
    {
        public int Insert(Customer obj)
        {
            string query = "Insert into Customer(UserID, CustomerName, CustomerMobile, CustomerPhone, Organization, City, CurrentBalance, OrganizationAddress, IsOld) values(@UserID, @CustomerName, @CustomerMobile, @CustomerPhone, @Organization, @City, @CurrentBalance,@OrganizationAddress, @IsOld)";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@UserID", obj.UserID));
            param.Add(new SqlParameter("@CustomerName", obj.CustomerName));
            param.Add(new SqlParameter("@CustomerMobile", obj.CustomerMobile));
            param.Add(new SqlParameter("@CustomerPhone", obj.CustomerPhone));
            param.Add(new SqlParameter("@Organization", obj.Organization));
            param.Add(new SqlParameter("@City", obj.City));
            param.Add(new SqlParameter("@CurrentBalance", obj.CurrentBalance));          
            param.Add(new SqlParameter("@OrganizationAddress", obj.OrganizationAddress));
            param.Add(new SqlParameter("@IsOld", obj.IsOld));

            return DataAccess.NonQuery(query, param);
        }

        public Customer SelectByID(int CustomerID)
        {
            string query = "Select * from Customer where CustomerID = @CustomerID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@CustomerID", CustomerID));

            DataTable dt = DataAccess.SelectData(query, param);
            if (dt.Rows.Count == 1)
            {
                Customer objMember = new Customer();
                objMember.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                objMember.CustomerName = dt.Rows[0]["CustomerName"].ToString();
                objMember.CustomerMobile = dt.Rows[0]["CustomerMobile"].ToString();
                objMember.CustomerPhone = dt.Rows[0]["CustomerPhone"].ToString();
                objMember.Organization = dt.Rows[0]["Organization"].ToString();
                objMember.City = dt.Rows[0]["City"].ToString();
                objMember.CurrentBalance = Convert.ToDouble(dt.Rows[0]["CurrentBalance"].ToString());
                objMember.OrganizationAddress = dt.Rows[0]["OrganizationAddress"].ToString();
                objMember.IsOld = Convert.ToBoolean(dt.Rows[0]["IsOld"].ToString());
                return objMember;
            }
            else
            {
                return new Customer();
            }
        }

        public int Update(Customer obj)
        {
            string query = "UPDATE Customer Set UserID=@UserID, CustomerName=@CustomerName, CustomerMobile=@CustomerMobile, CustomerPhone=@CustomerPhone, Organization=@Organization, City=@City, CurrentBalance=@CurrentBalance, OrganizationAddress=@OrganizationAddress, IsOld=@IsOld WHERE CustomerID=@CustomerID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            param.Add(new SqlParameter("@UserID", obj.UserID));
            param.Add(new SqlParameter("@CustomerName", obj.CustomerName));
            param.Add(new SqlParameter("@CustomerMobile", obj.CustomerMobile));
            param.Add(new SqlParameter("@CustomerPhone", obj.CustomerPhone));
            param.Add(new SqlParameter("@Organization", obj.Organization));
            param.Add(new SqlParameter("@City", obj.City));
            param.Add(new SqlParameter("@CurrentBalance", obj.CurrentBalance));
            param.Add(new SqlParameter("@OrganizationAddress", obj.OrganizationAddress));
            param.Add(new SqlParameter("@IsOld", obj.IsOld));
            
            return DataAccess.NonQuery(query, param);
        }

        public int Delete(int ID)
        {
            string query = "delete Customer where CustomerID = @CustomerID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@CustomerID", ID));

            return DataAccess.NonQuery(query, param);
        }

        public DataTable SelectAll()
        {
            return DataAccess.SelectData("select * from Customer order by Organization ASC", new List<SqlParameter>());
        }

        public List<Customer> SelectList()
        {
            DataTable dt = DataAccess.SelectData("select * from Customer", new List<SqlParameter>());
            List<Customer> cusList = new List<Customer>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Customer objMember = new Customer();
                objMember.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                objMember.CustomerName = dt.Rows[0]["CustomerName"].ToString();
                objMember.CustomerMobile = dt.Rows[0]["CustomerMobile"].ToString();
                objMember.CustomerPhone = dt.Rows[0]["CustomerPhone"].ToString();
                objMember.Organization = dt.Rows[0]["Organization"].ToString();
                objMember.City = dt.Rows[0]["City"].ToString();
                objMember.CurrentBalance = Convert.ToDouble(dt.Rows[0]["CurrentBalance"].ToString());
                objMember.OrganizationAddress = dt.Rows[0]["OrganizationAddress"].ToString();
                objMember.IsOld = Convert.ToBoolean(dt.Rows[0]["IsOld"].ToString());

                cusList.Add(objMember);
            }

            return cusList;
        }

        public Customer SelectByOrgName(string orgName)
        {
            string query = "Select * from Customer where Organization = @Organization";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Organization", orgName));

            DataTable dt = DataAccess.SelectData(query, param);
            if (dt.Rows.Count == 1)
            {
                Customer objMember = new Customer();
                objMember.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"].ToString());
                objMember.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                objMember.CustomerName = dt.Rows[0]["CustomerName"].ToString();
                objMember.CustomerMobile = dt.Rows[0]["CustomerMobile"].ToString();
                objMember.CustomerPhone = dt.Rows[0]["CustomerPhone"].ToString();
                objMember.Organization = dt.Rows[0]["Organization"].ToString();
                objMember.City = dt.Rows[0]["City"].ToString();
                objMember.CurrentBalance = Convert.ToDouble(dt.Rows[0]["CurrentBalance"].ToString());
                objMember.OrganizationAddress = dt.Rows[0]["OrganizationAddress"].ToString();
                objMember.IsOld = Convert.ToBoolean(dt.Rows[0]["IsOld"].ToString());
                return objMember;
            }
            else
            {
                return new Customer();
            }
        }



        public DataTable SelectNonOld()
        {
            return DataAccess.SelectData("select * from Customer where IsOld = 0", new List<SqlParameter>());
        }

        public DataTable GetTransactions(int p, DateTime dateTime, DateTime dateTime_2)
        {
            string qry = "select b.BillNumber,b.TotalAmount,v.Amount,v.VoucherNumber,c.* from Customer as c Inner Join Bill as b ON c.CustomerID = b.CustomerID Inner Join Voucher as v ON v.CustomerID = c.CustomerID where v.Date  between @StDate and @EndDate and b.CreatedOn between @StDate and @EndDate and b.CustomerId= @cusID and v.CustomerID = @cusID";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@cusID", p));
            paras.Add(new SqlParameter("@StDate", dateTime));
            paras.Add(new SqlParameter("@EndDate", dateTime_2));
            return DataAccess.SelectData(qry,paras);
        }

        public bool IsOrgExists(string p)
        {
            string qry = "select * from Customer where Organization = @org";
            List<SqlParameter> prams = new List<SqlParameter>();
            prams.Add(new SqlParameter("@org",p));
            DataTable dt = DataAccess.SelectData(qry, prams);
            if(dt.Rows.Count > 0 )
            {
                    return true;
            }
            else
            {
                return false;
            }
        }
    }
}
