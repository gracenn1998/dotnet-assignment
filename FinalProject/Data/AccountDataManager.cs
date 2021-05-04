using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.Data
{
    public class AccountDataManager
    {
        public DataRow getAccount(String email)
        {
            DataTable dt = new DataTable();
            try
            {
                clsDatabase.OpenConnection();
                String sql = "SELECT * FROM account WHERE email=@email";
                SqlDataAdapter sqlDa = new SqlDataAdapter(sql, clsDatabase.con);
               
                SqlParameter p1 = new SqlParameter("@email", SqlDbType.VarChar);
                p1.Value = email;
                sqlDa.SelectCommand.Parameters.Add(p1);

                sqlDa.Fill(dt);
                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0];
            }
            return null;
        }

        public DataRow getAccount(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                clsDatabase.OpenConnection();
                String sql = "SELECT * FROM account WHERE id=@id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(sql, clsDatabase.con);

                SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                p1.Value = id;
                sqlDa.SelectCommand.Parameters.Add(p1);

                sqlDa.Fill(dt);
                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0];
            }
            return null;
        }

        public int createAccount(Account account)
        {
            int id = -1;
            if (!doesEmailExist(account.email))
            {
                try
                {
                    clsDatabase.OpenConnection();
                    String sql = "INSERT INTO account(email, password, salt)" +
                        "VALUES(@email, @password, @salt);" +
                        "SELECT MAX(id) FROM account";

                    SqlCommand com = new SqlCommand(sql, clsDatabase.con);
                    SqlParameter p1 = new SqlParameter("@email", SqlDbType.VarChar);
                    p1.Value = account.email;
                    SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar);
                    p2.Value = account.hashed_password;
                    SqlParameter p3 = new SqlParameter("@salt", SqlDbType.VarChar);
                    p3.Value = account.salt;
                    
                    com.Parameters.Add(p1);
                    com.Parameters.Add(p2);
                    com.Parameters.Add(p3);
                    id = (int)com.ExecuteScalar();

                    clsDatabase.CloseConnection();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return id;
        }

        public Boolean doesEmailExist(string email)
        {
            if (getAccount(email) != null)
            {
                return true;
            }
            return false;
        }

        public void updateAccount(Account account)
        {
            try
            {
                clsDatabase.OpenConnection();
                String sql = "UPDATE account SET password=@password, salt=@salt WHERE id=@id";

                SqlCommand com = new SqlCommand(sql, clsDatabase.con);
                SqlParameter p1 = new SqlParameter("@password", SqlDbType.VarChar);
                p1.Value = account.hashed_password;
                SqlParameter p2 = new SqlParameter("@salt", SqlDbType.VarChar);
                p2.Value = account.salt;
                SqlParameter p3= new SqlParameter("@id", SqlDbType.Int);
                p3.Value = account.id;

                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                com.Parameters.Add(p3);
                com.ExecuteNonQuery();
                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public DataRow getToken(Account account)
        {
            DataTable dt = new DataTable();
            try
            {
                clsDatabase.OpenConnection();
                String sql = "SELECT * FROM AccountToken WHERE userid=@id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(sql, clsDatabase.con);

                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                p1.Value = account.id;
                sqlDa.SelectCommand.Parameters.Add(p1);

                sqlDa.Fill(dt);
                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0];
            }
            return null;
        }

        public void setToken(Account account, Token token)
        {
            try
            {

                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                p1.Value = account.id;
                SqlParameter p2 = new SqlParameter("@token", SqlDbType.VarChar);
                p2.Value = token.token;
                SqlParameter p3 = new SqlParameter("@expiretime", SqlDbType.DateTime);
                p3.Value = token.expireTime;
                String sql;
                if (getToken(account) != null)
                {
                    sql = "UPDATE AccountToken SET token=@token, ExpireTime=@expiretime WHERE userid=@id";

                }
                else
                {
                    sql = "INSERT INTO AccountToken(userid, token, expiretime)" +
                        "VALUES(@id, @token, @expiretime)";
                }

                clsDatabase.OpenConnection();
                SqlCommand com = new SqlCommand(sql, clsDatabase.con);
                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                com.Parameters.Add(p3);
                com.ExecuteNonQuery();
                clsDatabase.CloseConnection();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void activateAccount(Account account)
        {
            try
            {
                clsDatabase.OpenConnection();
                String sql = "UPDATE account SET isActivated=1 WHERE id=@id";

                SqlCommand com = new SqlCommand(sql, clsDatabase.con);
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                p1.Value = account.id;
                com.Parameters.Add(p1);
                com.ExecuteNonQuery();
                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }

    
}