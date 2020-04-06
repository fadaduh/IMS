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
    public class ProductLogic : ILogic<Product>
    {
        public int Insert(Product obj)
        {
            string query = "Insert into Product(ProductName, Description, Price, Quantity, UOM, BillID, ProductTypeID, IsDisable) values(@ProductName, @Description, @Price, @Quantity, @UOM, @BillID, @ProductTypeID, @IsDisable)";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductName", obj.ProductName));
            param.Add(new SqlParameter("@ProductTypeID", obj.ProductTypeID));
            param.Add(new SqlParameter("@Description", obj.Description));
            param.Add(new SqlParameter("@Price", obj.Price));
            param.Add(new SqlParameter("@Quantity", obj.Quantity));
            param.Add(new SqlParameter("@UOM", obj.UOM));
            param.Add(new SqlParameter("@BillID", obj.BillID));
            param.Add(new SqlParameter("@IsDisable", obj.IsDisable));

            return DataAccess.NonQuery(query, param);
        }

        public Product SelectByID(int ProductID)
        {
            string query = "Select * from Product where ProductID = @ProductID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductID", ProductID));

            DataTable dt = DataAccess.SelectData(query, param);
            if (dt.Rows.Count == 1)
            {
                Product objMember = new Product();
                objMember.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"].ToString());
                objMember.ProductName = dt.Rows[0]["ProductName"].ToString();
                objMember.ProductTypeID = Convert.ToInt32(dt.Rows[0]["ProductTypeID"].ToString());
                objMember.Description = dt.Rows[0]["Description"].ToString();
                objMember.Price = Convert.ToDouble(dt.Rows[0]["Price"].ToString());
                objMember.Quantity =Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                objMember.UOM = dt.Rows[0]["UOM"].ToString();
                objMember.BillID = Convert.ToInt32(dt.Rows[0]["BillID"].ToString());
                objMember.IsDisable = Convert.ToBoolean(dt.Rows[0]["IsDisable"].ToString());

                return objMember;
            }
            else
            {
                return new Product();
            }
        }

        public int Update(Product obj)
        {
            string query = "UPDATE Product Set ProductName=@ProductName, Description=@Description, Price=@Price, Quantity=@Quantity, UOM=@UOM, BillID=@BillID, ProductTypeID=@ProductTypeID, IsDisable = @IsDisable WHERE ProductID = @ProductID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductID", obj.ProductID));
            param.Add(new SqlParameter("@ProductName", obj.ProductName));
            param.Add(new SqlParameter("@ProductTypeID", obj.ProductTypeID));
            param.Add(new SqlParameter("@Description", obj.Description));
            param.Add(new SqlParameter("@Price", obj.Price));
            param.Add(new SqlParameter("@Quantity", obj.Quantity));
            param.Add(new SqlParameter("@UOM", obj.UOM));
            param.Add(new SqlParameter("@BillID", obj.BillID));
            param.Add(new SqlParameter("@IsDisable", obj.IsDisable));

            return DataAccess.NonQuery(query, param);
        }

        public int Delete(int ID)
        {
            string query = "delete Product where ProductID = @ProductID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductID", ID));

            return DataAccess.NonQuery(query, param);
        }

        public DataTable SelectAll()
        {
            return DataAccess.SelectData("select * from Product order by ProductName", new List<SqlParameter>());
        }

        public List<Product> SelectList()
        {
            DataTable dt = DataAccess.SelectData("select * from Product", new List<SqlParameter>());
            List<Product> productList = new List<Product>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Product objMember = new Product();
                objMember.ProductName = dt.Rows[0]["ProductName"].ToString();
                objMember.ProductTypeID = Convert.ToInt32(dt.Rows[0]["ProductTypeID"].ToString());
                objMember.Description = dt.Rows[0]["Description"].ToString();
                objMember.Price = Convert.ToDouble(dt.Rows[0]["Price"].ToString());
                objMember.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                objMember.UOM = dt.Rows[0]["UOM"].ToString();
                objMember.BillID = Convert.ToInt32(dt.Rows[0]["BillID"].ToString());
                objMember.IsDisable = Convert.ToBoolean(dt.Rows[0]["IsDisable"].ToString());

                productList.Add(objMember);
            }

            return productList;
        }



        public DataTable selectRelatedTypes(int  productTypeID)
        {
            string qry = "select * from Product where ProductTypeID = @ProductTypeID order by ProductName";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductTypeID", productTypeID));
            return DataAccess.SelectData(qry, param);

        }

        public DataTable SelectAllTypeGrp()
        {
            return DataAccess.SelectData("select DISTINCT ProductType  from Product", new List<SqlParameter>());
        }



        public Product getRate(int ProductTypeID, string productName)
        {
            string query = "select * from Product where ProductTypeID = @ProductTypeID and ProductName = @ProductName";

            List<SqlParameter> lstparam = new List<SqlParameter>();
            lstparam.Add(new SqlParameter("ProductTypeID", ProductTypeID));
            lstparam.Add(new SqlParameter("ProductName", productName));

            DataTable dt = DataAccess.SelectData(query, lstparam);

            if (dt.Rows.Count == 1)
            {

                int id = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                Product p = SelectByID(id);
                return p;
            }
            else
            {
                return new Product();
            }
        }

        public DataTable SelectAllWithProductType()
        {
            string qry = "select p.*,pt.ProductTypeName from Product as p inner join ProductType as pt on p.ProductTypeID = pt.ProductTypeID order by p.ProductID DESC";
            return DataAccess.SelectData(qry,new List<SqlParameter>());
        }
    }
}
