using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    class clsDatabase
    {
        public static SqlConnection con;

        public static bool OpenConnection()
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString =
                    "Data Source=localhost;" +
                    "Initial Catalog=timetable_management;" +
                    "User id=mylogin;" +
                    "Password=mylogin;";
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Open connection failed");
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public static bool CloseConnection()
        {
            try
            {
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
