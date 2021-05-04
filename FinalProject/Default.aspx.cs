using FinalProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class _Default : Page
    {
        private int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userid"] == null)
            {
                
                divTimetable.Visible = false;
                divJumbotron.Visible = true;
            }
            else
            {
                divTimetable.Visible = true;
                divJumbotron.Visible = false;
                userid = int.Parse(Request.Cookies["userid"].Value);

                string email = new AccountDataManager().getAccount(userid)["email"].ToString();
                lblEmail.Text = email;

                if (!IsPostBack)
                {
                    LoadEvents();
                }
            }

        }

        private void LoadEvents()
        {
            DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek(DateTime.Now);
            DateTime start = DayPilotCalendar1.StartDate;
            DateTime end = DayPilotCalendar1.EndDate.AddDays(1);
            DayPilotCalendar1.DataSource = new EventDataManager().getEvents(userid, start, end);
            DayPilotCalendar1.DataBind();
        }

        protected void DayPilotCalendar1_EventMove(object sender, DayPilot.Web.Ui.Events.EventMoveEventArgs e)
        {
            Response.Write(e.Data);
            new EventDataManager().moveEvent(int.Parse(e.Id), e.NewStart, e.NewEnd);
            DateTime start = DayPilotCalendar1.StartDate;
            DateTime end = DayPilotCalendar1.EndDate.AddDays(1);
            DayPilotCalendar1.DataSource = new EventDataManager().getEvents(userid, start, end);
            DayPilotCalendar1.DataBind();
            DayPilotCalendar1.Update();
        }



        protected void DayPilotCalendar1_Command(object sender, DayPilot.Web.Ui.Events.CommandEventArgs e)
        {
            switch (e.Command)
            {
                case "navigate":
                    DateTime start = (DateTime)e.Data["start"];
                    DayPilotCalendar1.StartDate = start;
                    DateTime end = DayPilotCalendar1.EndDate.AddDays(1);
                    DayPilotCalendar1.DataSource = new EventDataManager().getEvents(userid, start, end);
                    DayPilotCalendar1.DataBind();
                    DayPilotCalendar1.Update(DayPilot.Web.Ui.Enums.CallBackUpdateType.Full);
                    break;
                case "refresh":
                    LoadEvents();

                    if (e.Data != null && e.Data["message"] != null)
                    {
                        DayPilotCalendar1.UpdateWithMessage((string)e.Data["message"]);
                    }
                    else
                    {
                        DayPilotCalendar1.UpdateWithMessage("Updated.");
                    }
                    break;
            }
        }


        protected void DayPilotCalendar1_BeforeEventRender(object sender, DayPilot.Web.Ui.Events.Calendar.BeforeEventRenderEventArgs e)
        {
            string color = (string)e.DataItem["color"];
            if (!String.IsNullOrEmpty(color))
            {
                e.BackgroundColor = color;
                e.BorderColor = color;
                e.FontColor = "#ffffff";
            }
        }

        protected void DayPilotCalendar1_EventResize(object sender, DayPilot.Web.Ui.Events.EventResizeEventArgs e)
        {
            new EventDataManager().moveEvent(Convert.ToInt32(e.Id), e.NewStart, e.NewEnd);
            DateTime start = DayPilotCalendar1.StartDate;
            DateTime end = DayPilotCalendar1.EndDate.AddDays(1);
            DayPilotCalendar1.DataSource = new EventDataManager().getEvents(userid, start, end);
            DayPilotCalendar1.DataBind();
            DayPilotCalendar1.Update();
        }

        protected void ButtonSignin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Signin.aspx");
        }

        protected void ButtonSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Signup.aspx");
        }
    }
}