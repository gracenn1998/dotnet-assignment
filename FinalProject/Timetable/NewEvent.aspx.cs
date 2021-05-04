using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using DayPilot.Utils;
using DayPilot.Web.Ui.Enums;
using FinalProject.Data;

namespace FinalProject.Timetable
{
    public partial class NewEvent : System.Web.UI.Page
    {
        private FinalProject.Data.Event ev = new FinalProject.Data.Event();
        private String date, startStr, endStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userid"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            else
            {
                ev.userid = int.Parse(Request.Cookies["userid"].Value);
                if (!IsPostBack)
                {
                    ev.start = Convert.ToDateTime(Request.QueryString["start"]);
                    ev.end = Convert.ToDateTime(Request.QueryString["end"]);
                    startStr = ev.start.ToString("HH:mm");
                    endStr = ev.end.ToString("HH:mm");
                    txtDate.Text = ev.start.ToString("dd/MM/yyyy");
                    txtStart.Text = startStr;
                    txtEnd.Text = endStr;
                }
            }
            
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {

            //DateTime end = Convert.ToDateTime(TextBoxEnd.Text);
            date = txtDate.Text;
            startStr = txtStart.Text;
            endStr = txtEnd.Text;
            ev.title = txtTitle.Text;
            ev.color = drpColor.SelectedValue;
            ev.description = txtDescription.Text;
            ev.start = DateTime.ParseExact(date + " " + startStr, "dd/MM/yyyy HH:mm", null);
            ev.end = DateTime.ParseExact(date + " " + endStr, "dd/MM/yyyy HH:mm", null);

            new EventDataManager().createEvent(ev);

            // passed to the modal dialog close handler, see Scripts/DayPilot/event_handling.js
            Hashtable ht = new Hashtable();
            ht["refresh"] = "yes";
            ht["message"] = "Event created.";

            Modal.Close(this, ht);
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Modal.Close(this);
        }
    }

}