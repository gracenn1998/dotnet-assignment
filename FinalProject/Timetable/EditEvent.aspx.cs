using FinalProject.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Timetable
{
    public partial class EditEvent : System.Web.UI.Page
    {
        private FinalProject.Data.Event ev = new FinalProject.Data.Event();
        private String date, startStr, endStr;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userid"] == null || Request.QueryString["id"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            else
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                //ev.userid = 1;
                ev.userid = int.Parse(Request.Cookies["userid"].Value);
                ev.id = int.Parse(Request.QueryString["id"]);
                if (!IsPostBack)
                {
                    DataRow dr = new EventDataManager().getEvent(ev.id);
                    ev.start = Convert.ToDateTime(dr["eventstart"]);
                    ev.end = Convert.ToDateTime(dr["eventend"]);
                    ev.description = dr["description"].ToString();
                    ev.title = dr["title"].ToString();
                    ev.color = dr["color"].ToString();
                    date = ev.start.ToString("dd/MM/yyyy");
                    startStr = ev.start.ToString("HH:mm");
                    endStr = ev.end.ToString("HH:mm");

                    txtDate.Text = date;
                    txtStart.Text = startStr;
                    txtEnd.Text = endStr;
                    txtTitle.Text = ev.title;
                    txtDescription.Text = ev.description;
                    drpColor.SelectedValue = ev.color;

                    //DataBind();
                }
            }
            
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            date = txtDate.Text;
            startStr = txtStart.Text;
            endStr = txtEnd.Text;

            ev.start = DateTime.ParseExact(date + " " + startStr, "dd/MM/yyyy HH:mm", null);
            ev.end = DateTime.ParseExact(date + " " + endStr, "dd/MM/yyyy HH:mm", null);
            ev.title = txtTitle.Text;
            ev.color = drpColor.SelectedValue;
            ev.description = txtDescription.Text;

            new EventDataManager().updateEvent(ev);

            Hashtable ht = new Hashtable();
            ht["refresh"] = "yes";
            ht["message"] = "Event updated.";

            Modal.Close(this, ht);
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Modal.Close(this);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            new EventDataManager().deleteEvent(ev.id);
            Hashtable ht = new Hashtable();
            ht["refresh"] = "yes";
            ht["message"] = "Event deleted.";
            Modal.Close(this, ht);
        }
    }
}