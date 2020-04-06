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
    public class ProductTypeLogic : ILogic<ProductType>
    {
        public int Insert(ProductType obj)
        {
            string query = "Insert into ProductType (ProductTypeName, PTDescription) values(@ProductTypeName, @PTDescription)";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductTypeName", obj.ProductTypeName));
            param.Add(new SqlParameter("@PTDescription", obj.PTDescription));       

            return DataAccess.NonQuery(query, param);
        }

        public ProductType SelectByID(int ProductTypeID)
        {
            string query = "Select * from ProductType where ProductTypeID = @ProductTypeID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductTypeID", ProductTypeID));

            DataTable dt = DataAccess.SelectData(query, param);
            if (dt.Rows.Count == 1)
            {
                ProductType objMember = new ProductType();
                objMember.ProductTypeName = dt.Rows[0]["ProductTypeName"].ToString();
                objMember.PTDescription = dt.Rows[0]["PTDescription"].ToString();   

                return objMember;
            }
            else
            {
                return new ProductType();
            }
        }

        public int Update(ProductType obj)
        {
            string query = "UPDATE ProductType Set ProductTypeName=@ProductTypeName, PTDescription=@PTDescription WHERE ProductTypeID = @ProductTypeID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductTypeName", obj.ProductTypeName));
            param.Add(new SqlParameter("@PTDescription", obj.PTDescription));           
            return DataAccess.NonQuery(query, param);
        }

        public int Delete(int ID)
        {
            string query = "delete ProductType where ProductTypeID = @ProductTypeID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductTypeID", ID));

            return DataAccess.NonQuery(query, param);
        }

        public DataTable SelectAll()
        {
            return DataAccess.SelectData("select * from ProductType order by ProductTypeName", new List<SqlParameter>());
        }

        public List<ProductType> SelectList()
        {
            DataTable dt = DataAccess.SelectData("select * from ProductType", new List<SqlParameter>());
            List<ProductType> productList = new List<ProductType>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductType objMember = new ProductType();
                objMember.ProductTypeName = dt.Rows[0]["ProductTypeName"].ToString();
                objMember.PTDescription = dt.Rows[0]["PTDescription"].ToString();
                productList.Add(objMember);
            }

            return productList;
        }



        public ProductType selectByName(string productTypeName)
        {
            string query = "Select * from ProductType where ProductTypeName = @ProductTypeName";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductTypeName", productTypeName));

            DataTable dt = DataAccess.SelectData(query, param);
            if (dt.Rows.Count == 1)
            {
                ProductType objMember = new ProductType();
                objMember.ProductTypeID = Convert.ToInt32(dt.Rows[0]["ProductTypeID"].ToString());
                objMember.ProductTypeName = dt.Rows[0]["ProductTypeName"].ToString();
                objMember.PTDescription = dt.Rows[0]["PTDescription"].ToString();

                return objMember;
            }
            else
            {
                return new ProductType();
            }
        }

        public bool IsExists(string p)
        {
            string qry = "select * from ProductType where ProductTypeName = @ptName";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ptName",p));
            DataTable dt = DataAccess.SelectData(qry,param);
            if (dt.Rows.Count > 0)
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
