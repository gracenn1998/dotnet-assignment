using DayPilot.Web.Ui;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalProject.Data
{
    public class EventDataManager
    {

        public void createEvent(FinalProject.Data.Event e)
        {
            try
            {
                clsDatabase.OpenConnection();
                String sql = "INSERT INTO event(userid, title, eventstart, eventend, description, color)" +
                    "VALUES(@userid, @title, @start, @end, @des, @color)";

                SqlCommand com = new SqlCommand(sql, clsDatabase.con);
                SqlParameter p1 = new SqlParameter("@userid", SqlDbType.Int);
                p1.Value = e.userid;
                SqlParameter p2 = new SqlParameter("@title", SqlDbType.NVarChar);
                p2.Value = e.title;
                SqlParameter p3 = new SqlParameter("@start", SqlDbType.DateTime);
                p3.Value = e.start;
                SqlParameter p4 = new SqlParameter("@end", SqlDbType.DateTime);
                p4.Value = e.end;
                SqlParameter p5 = new SqlParameter("@des", SqlDbType.NVarChar);
                p5.Value = e.description;
                SqlParameter p6 = new SqlParameter("@color", SqlDbType.NVarChar);
                p6.Value = e.color;

                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                com.Parameters.Add(p3);
                com.Parameters.Add(p4);
                com.Parameters.Add(p5);
                com.Parameters.Add(p6);
                com.ExecuteNonQuery();
                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void deleteEvent(int id)
        {
            try
            {
                clsDatabase.OpenConnection();
                String sql = "DELETE FROM event WHERE id=@id";

                SqlCommand com = new SqlCommand(sql, clsDatabase.con);
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                p1.Value = id;
           
                com.Parameters.Add(p1);
                com.ExecuteNonQuery();
                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public object getEvents(int userid, DateTime start, DateTime end)
        {
            DataTable dt = new DataTable();
            try
            {
                clsDatabase.OpenConnection();
                String sql = "SELECT * FROM event WHERE userid=@userid AND NOT ((eventend <= @start) OR (eventstart >= @end))";

                SqlDataAdapter sqlDa = new SqlDataAdapter(sql, clsDatabase.con);
                SqlParameter p1 = new SqlParameter("@userid", SqlDbType.Int);
                p1.Value = userid;
                SqlParameter p2 = new SqlParameter("@start", SqlDbType.DateTime);
                p2.Value = start;
                SqlParameter p3 = new SqlParameter("@end", SqlDbType.DateTime);
                p3.Value = end;
                sqlDa.SelectCommand.Parameters.Add(p1);
                sqlDa.SelectCommand.Parameters.Add(p2);
                sqlDa.SelectCommand.Parameters.Add(p3);

                sqlDa.Fill(dt);
                
                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return dt;
        }

        public void moveEvent(int id, DateTime start, DateTime end)
        {
            try
            {
                clsDatabase.OpenConnection();
                String sql = "UPDATE event SET eventstart=@start, eventend=@end WHERE id=@id";

                SqlCommand com = new SqlCommand(sql, clsDatabase.con);
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                p1.Value = id;
                SqlParameter p2 = new SqlParameter("@start", SqlDbType.DateTime);
                p2.Value = start;
                SqlParameter p3 = new SqlParameter("@end", SqlDbType.DateTime);
                p3.Value = end;

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

        public void updateEvent(FinalProject.Data.Event e)
        {
            try
            {
                clsDatabase.OpenConnection();
                String sql = "UPDATE event SET eventstart=@start, eventend=@end, title=@title, color=@color WHERE id=@id";

                SqlCommand com = new SqlCommand(sql, clsDatabase.con);
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
                p1.Value = e.id;
                SqlParameter p2 = new SqlParameter("@title", SqlDbType.NVarChar);
                p2.Value = e.title;
                SqlParameter p3 = new SqlParameter("@start", SqlDbType.DateTime);
                p3.Value = e.start;
                SqlParameter p4 = new SqlParameter("@end", SqlDbType.DateTime);
                p4.Value = e.end;
                SqlParameter p5 = new SqlParameter("@des", SqlDbType.NVarChar);
                p5.Value = e.description;
                SqlParameter p6 = new SqlParameter("@color", SqlDbType.NVarChar);
                p6.Value = e.color;

                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                com.Parameters.Add(p3);
                com.Parameters.Add(p4);
                com.Parameters.Add(p5);
                com.Parameters.Add(p6);
                com.ExecuteNonQuery();
                clsDatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
 
        }

        public DataRow getEvent(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                clsDatabase.OpenConnection();
                String sql = "SELECT * FROM event WHERE id=@id";

                SqlDataAdapter sqlDa = new SqlDataAdapter(sql, clsDatabase.con);
                sqlDa.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

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

    }
}