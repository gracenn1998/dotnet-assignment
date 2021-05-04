<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalProject._Default" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<asp:Content ID="Default" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" id="divTimetable">
        <div class="row p-0 m-0">
            <div class="d-flex flex-column p-2 bg-light" style="width: 200px;">
                <div class="d-flex mx-auto">
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                </div>
                <ul class="nav nav-pills flex-column mb-auto mt-2">
                    <li class="nav-item card p-1 mx-auto">
                        <DayPilot:DayPilotNavigator 
                            ID="DayPilotNavigator1"
                            runat="server"
                            BoundDayPilotID="DayPilotCalendar1"
                            ShowMonths="1"
                            SelectMode="Week"
                        />
                    </li>
                    <li class="nav-item p-1 mt-2">
                      <a href="/Account/ChangePassword" class="nav-link active">
                        Change Password
                      </a>
                    </li>
                </ul>
            </div>
            <div class="col p-0 card mx-auto">
                <daypilot:daypilotcalendar 
                    id="DayPilotCalendar1" 
                    runat="server" 
                    DataStartField="eventstart" 
                    DataEndField="eventend"
                    DataTextField="title" 
                    DataValueField="id" 
                    Days="7" 

                    OnEventMove="DayPilotCalendar1_EventMove" 
                    EventMoveHandling="CallBack" OnCommand="DayPilotCalendar1_Command"
                    CellDuration="60"
                    CellHeight="30"
                    DayBeginsHour="7"
                    HeightSpec="Full" OnBeforeEventRender="DayPilotCalendar1_BeforeEventRender" OnEventResize="DayPilotCalendar1_EventResize"

                    ClientObjectName="dp"
                    TimeRangeSelectedHandling="JavaScript"
                    TimeRangeSelectedJavaScript="create(start, end, resource);"
                    EventClickHandling="JavaScript"
                    EventClickJavaScript="edit(e)" CssClass="auto-style1"
                >
                </daypilot:daypilotcalendar>
            </div>  
        </div>
        
    </div>


    <div runat="server" id="divJumbotron" class="jumbotron">
        <h1 class="display-4">Hello!</h1>
            <p class="lead">This is a simple timetable application, where you can manage your shedules!</p>
        <hr class="my-4">
        <p>Try it now!</p>
        <p class="lead">
            <asp:LinkButton runat="server" id="btnSignin" CssClass="btn btn-outline-primary me-2" OnClick="ButtonSignin_Click" Text="Sign In"></asp:LinkButton>
            <asp:LinkButton runat="server" id="btnSignup" CssClass="btn btn-info me-2" OnClick="ButtonSignup_Click" Text="Sign Up"></asp:LinkButton>
        </p>
    </div>
</asp:Content>
