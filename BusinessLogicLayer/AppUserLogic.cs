using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class AppUserLogic : ILogic<AppUser>
    {
        public int Insert(AppUser obj)
        { 
            string query = "Insert into AppUser(Username, Password, Name, Phone, Mobile, Email, Type, City, AccountNumber, BankName, Address) values(@Username, @Password, @Name @Phone, @Mobile, @Email, @Type , @City, @AccountNumber, @BankName, @Address)";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@UserName", obj.UserName));
            param.Add(new SqlParameter("@Password", obj.Password));            
            param.Add(new SqlParameter("@Name", obj.Name));
            param.Add(new SqlParameter("@Phone", obj.Phone));
            param.Add(new SqlParameter("@Mobile", obj.Mobile));
            param.Add(new SqlParameter("@Email", obj.Email));
            param.Add(new SqlParameter("@Type", obj.Type));
            param.Add(new SqlParameter("@City", obj.City));
            param.Add(new SqlParameter("@LastSeenUpdateID", obj.AccountNumber));
            param.Add(new SqlParameter("@UserStatus", obj.BankName));
            param.Add(new SqlParameter("@Address", obj.Address));

            return DataAccess.NonQuery(query, param);
        }

        public AppUser SelectByID(int UserID)
        {
            string query = "Select * from AppUser where UserID = @UserID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@UserID", UserID));

            DataTable dt = DataAccess.SelectData(query, param);
            if (dt.Rows.Count == 1)
            {
                AppUser objMember = new AppUser();
                objMember.UserName = dt.Rows[0]["UserName"].ToString();
                objMember.Password = dt.Rows[0]["Password"].ToString();
                objMember.Name = dt.Rows[0]["Name"].ToString();
                objMember.Phone = dt.Rows[0]["Phone"].ToString();
                objMember.Mobile = dt.Rows[0]["Mobile"].ToString();
                objMember.Email = dt.Rows[0]["Email"].ToString();
                objMember.Type = dt.Rows[0]["Type"].ToString();
                objMember.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                objMember.City = dt.Rows[0]["City"].ToString();
                objMember.AccountNumber = dt.Rows[0]["AccountNumber"].ToString();
                objMember.BankName = dt.Rows[0]["BankName"].ToString();
                objMember.Address = dt.Rows[0]["Address"].ToString();

                return objMember;
            }
            else
            {
                return new AppUser();
            }
        }

        public int Update(AppUser obj)
        {
            string query = "UPDATE AppUser Set UserName = @UserName, Password = @Password, Name = @Name, Phone = @phone, Mobile = @Mobile, Email = @Email, Type = @Type ,City = @City, AccountNumber = @AccountNumber, BankName = @BankName, Address = @Address  WHERE UserID = @UserID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@UserName", obj.UserName));
            param.Add(new SqlParameter("@Password", obj.Password));
            param.Add(new SqlParameter("@Name", obj.Name));
            param.Add(new SqlParameter("@Phone", obj.Phone));
            param.Add(new SqlParameter("@Mobile", obj.Mobile));
            param.Add(new SqlParameter("@Email", obj.Email));
            param.Add(new SqlParameter("@Type", obj.Type));
            param.Add(new SqlParameter("@UserID", obj.UserID));
            param.Add(new SqlParameter("@City", obj.City));
            param.Add(new SqlParameter("@AccountNumber", obj.AccountNumber));
            param.Add(new SqlParameter("@BankName", obj.BankName));
            param.Add(new SqlParameter("@Address", obj.Address));

            return DataAccess.NonQuery(query, param);
        }

        public int Delete(int ID)
        {
            string query = "delete AppUser where UserID = @UserID";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@UserID", ID));

            return DataAccess.NonQuery(query, param);
        }

        public DataTable SelectAll()
        {
            return DataAccess.SelectData("select * from AppUser", new List<SqlParameter>());
        }

        public List<AppUser> SelectList()
        {
            DataTable dt = DataAccess.SelectData("select * from AppUser", new List<SqlParameter>());
            List<AppUser> lstUser = new List<AppUser>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AppUser objMember = new AppUser();
                objMember.UserName = dt.Rows[0]["UserName"].ToString();
                objMember.Password = dt.Rows[0]["Password"].ToString();
                objMember.Name = dt.Rows[0]["Name"].ToString();
                objMember.Phone = dt.Rows[0]["Phone"].ToString();
                objMember.Mobile = dt.Rows[0]["Mobile"].ToString();
                objMember.Email = dt.Rows[0]["Email"].ToString();
                objMember.Type = dt.Rows[0]["Type"].ToString();
                objMember.UserID = Convert.ToInt32(dt.Rows[i]["UserID"].ToString());
                objMember.City = dt.Rows[0]["City"].ToString();
                objMember.AccountNumber = dt.Rows[i]["AccountNumber"].ToString();
                objMember.BankName = dt.Rows[0]["BankName"].ToString();
                objMember.Address = dt.Rows[0]["Address"].ToString();
                lstUser.Add(objMember);
            }

            return lstUser;
        }

        public DataTable Search(string Name)
        {
            string query = "select * from AppUser where name like @Name+'%'";

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Name", Name));

            return DataAccess.SelectData(query, param);
        }


        public AppUser IsValid(string UserName, string Password)
        {
            string query = "select * from AppUser where UserName = @UserName";

            List<SqlParameter> lstparam = new List<SqlParameter>();
            lstparam.Add(new SqlParameter("UserName", UserName));

            DataTable dt = DataAccess.SelectData(query, lstparam);

            if (dt.Rows.Count == 1 && dt.Rows[0]["Password"].ToString() == Password)
            {

                int id = Convert.ToInt32(dt.Rows[0]["UserID"]);
                AppUser a = SelectByID(id);
                return a;
            }
            else
            {
                return new AppUser();
            }
        }
    }
}
