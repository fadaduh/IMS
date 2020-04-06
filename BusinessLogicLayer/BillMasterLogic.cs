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
    public class BillMasterLogic : ILogic<BillMaster>
    {
        public int Insert(BillMaster obj)
        {
            string query = "Insert into BillMaster(BillID, ProductID, Quantity, BillRate, BillValue) values(@BillID, @ProductID, @Quantity, @BillRate, @BillValue)";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@BillID", obj.BillID));
            param.Add(new SqlParameter("@ProductID", obj.ProductID));
            param.Add(new SqlParameter("@Quantity", obj.Quantity));
            param.Add(new SqlParameter("@BillRate", obj.BillRate));
            param.Add(new SqlParameter("@BillValue", obj.BillValue));


            return DataAccess.NonQuery(query, param);
        }

        public BillMaster SelectByID(int BillMID)
        {
            string query = "Select * from Bill where BillMID = @BillMID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@BillMID", BillMID));

            DataTable dt = DataAccess.SelectData(query, param);
            if (dt.Rows.Count == 1)
            {
                BillMaster objMember = new BillMaster();
                objMember.BillID = Convert.ToInt32(dt.Rows[0]["BillID"].ToString());
                objMember.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"].ToString());
                objMember.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                objMember.BillRate = Convert.ToDouble(dt.Rows[0]["BillRate"].ToString());
                objMember.BillValue = Convert.ToDouble(dt.Rows[0]["BillValue"].ToString());

                return objMember;
            }
            else
            {
                return new BillMaster();
            }
        }

        public int Update(BillMaster obj)
        {
            string query = "UPDATE BillMaster Set BillID=@BillID, ProductID=@ProductID, Quantity=@Quantity, BillRate=@BillRate, BillValue=@BillValue  WHERE BillMID = @BillMID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@BillID", obj.BillID));
            param.Add(new SqlParameter("@ProductID", obj.ProductID));
            param.Add(new SqlParameter("@Quantity", obj.Quantity));
            param.Add(new SqlParameter("@BillRate", obj.BillRate));
            param.Add(new SqlParameter("@BillValue", obj.BillValue));

            return DataAccess.NonQuery(query, param);
        }

        public int Delete(int ID)
        {
            string query = "delete BillMaster where BillMID = @BillMID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@BillMID", ID));

            return DataAccess.NonQuery(query, param);
        }

        public DataTable SelectAll()
        {
            return DataAccess.SelectData("select * from BillMaster", new List<SqlParameter>());
        }

        public List<BillMaster> SelectList()
        {
            DataTable dt = DataAccess.SelectData("select * from Bill", new List<SqlParameter>());
            List<BillMaster> billlist = new List<BillMaster>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BillMaster objMember = new BillMaster();
                objMember.BillID = Convert.ToInt32(dt.Rows[0]["BillID"].ToString());
                objMember.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"].ToString());
                objMember.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                objMember.BillRate = Convert.ToDouble(dt.Rows[0]["BillRate"].ToString());
                objMember.BillValue =  Convert.ToDouble(dt.Rows[0]["BillValue"].ToString());

                billlist.Add(objMember);
            }

            return billlist;
        }

        public DataTable SelectByBillID(int billId)
        {
            string qry = "Select bm.*,p.ProductName,p.ProductTypeID,pt.ProductTypeName from BillMaster as bm inner join Product as p ON bm.ProductID = p.ProductID inner join ProductType as pt ON p.ProductTypeID = pt.ProductTypeID  where bm.BillID = @BillID";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@BillID", billId));
            return DataAccess.SelectData(qry, param);
            
        }
    }
}
