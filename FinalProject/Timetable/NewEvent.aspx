<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEvent.aspx.cs" Inherits="FinalProject.Timetable.NewEvent" Culture = "en-GB"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <webopt:bundlereference runat="server" path="~/Content/css" />

    <style>
    body {
        margin: 0;
        padding: 0;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card p-3 mt-2 mb-2 mx-auto" style="width: 27rem;">
            <h5 class="card-title text-center bg-dark text-light w-100">New Event</h5>
            <div class="form-group row">
                <label for="txtTitle" class="col-3 col-form-label">Title: </label>
                <div class="col">
                    <asp:TextBox ID="txtTitle" runat="server" style="width:100%;" CssClass="form-control"></asp:TextBox>
        
                    <small id="titleHelp" class="form-text text-muted">
                         <asp:RequiredFieldValidator ID="rf_Title" runat="server" ControlToValidate="txtTitle" ErrorMessage="Please enter title" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </small>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtDate" class="col-3 col-form-label">Date: </label>
                <div class="col">
                    <asp:TextBox ID="txtDate" runat="server" style="width:100%;" CssClass="form-control" placeholder="dd/MM/yyyy"></asp:TextBox>
        
                    <small id="dateHelp" class="form-text text-muted">
                        <asp:RequiredFieldValidator ID="rf_Date" runat="server" ControlToValidate="txtDate" ErrorMessage="Pleaser enter date" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_Date" runat="server" ControlToValidate="txtDate" ErrorMessage="Invalid date format" ForeColor="Red" Operator="DataTypeCheck" Type="Date" Display="Dynamic"></asp:CompareValidator>
                    </small>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtStart" class="col-3 col-form-label">Start: </label>
                <div class="col">
                    <asp:TextBox ID="txtStart" runat="server" style="width:100%;" CssClass="form-control" placeholder="hh:mm"></asp:TextBox>
        
                    <small id="startHelp" class="form-text text-muted">
                        <asp:RequiredFieldValidator ID="rf_Start" runat="server" ControlToValidate="txtStart" ErrorMessage="Please enter starting time" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rv_Start" runat="server" ControlToValidate="txtStart" ErrorMessage="Invalid time format" ForeColor="Red" ValidationExpression="^[0-2][0-9]:[0-5][0-9]$"  Display="Dynamic"></asp:RegularExpressionValidator>
                    </small>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtEnd" class="col-3 col-form-label">End: </label>
                <div class="col">
                    <asp:TextBox ID="txtEnd" runat="server" style="width:100%;" CssClass="form-control" placeholder="hh:mm"></asp:TextBox></td>
                
                    <small id="endHelp" class="form-text text-muted">
                        <asp:RequiredFieldValidator ID="rf_End" runat="server" ControlToValidate="txtEnd" ErrorMessage="Please enter ending time" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rv_End" runat="server" ControlToValidate="txtEnd" ErrorMessage="Invalid time format" ForeColor="Red" ValidationExpression="^[0-2][0-9]:[0-5][0-9]$" Display="Dynamic"></asp:RegularExpressionValidator>
                    </small>    
                </div>
            </div>

            <div class="form-group row">
                <label for="drpColor" class="col-3 col-form-label">Color: </label>
                <div class="col">
                    <asp:DropDownList ID="drpColor" runat="server" CssClass="form-control" style="width:100%;">
                        <asp:ListItem Value="">(default)</asp:ListItem>
                        <asp:ListItem Value="#666666">Gray</asp:ListItem>
                        <asp:ListItem Value="#008e00">Green</asp:ListItem>
                        <asp:ListItem Value="#d74f29">Red</asp:ListItem>
                        <asp:ListItem Value="#004dc3">Blue</asp:ListItem>
                        <asp:ListItem Value="#eab71e">Yellow</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label for="txtDescription" class="col-3 col-form-label">Note: </label>
                <div class="col">
                    <asp:TextBox ID="txtDescription" runat="server" style="width:100%;" CssClass="form-control w-100" TextMode="MultiLine"></asp:TextBox></td>
                </div>
            </div>

             <div class="row w-100 mx-auto">
                  <asp:LinkButton runat="server" id="btnOk" CssClass="btn btn-primary w-100" OnClick="ButtonOK_Click" Text="OK"></asp:LinkButton>
            </div>

        </div>
    </form>
</body>
</html>
