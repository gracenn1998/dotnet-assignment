<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="FinalProject.Account.ForgotPassword" %>

<asp:Content ID="ForgotPassword" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card p-3 mx-auto mt-3" style="width: 20rem;">
        <h5 class="card-title mx-auto">Forgot Password</h5>
        <div class="form-group">
            <asp:TextBox ID="txtEmail" runat="server" style="width:100%;" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
        
            <small id="emailHelp" class="form-text text-muted">
                <asp:RequiredFieldValidator ID="rv_Email" runat="server" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic">Please enter email</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_Email" runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">Invalid Email</asp:RegularExpressionValidator>
            </small>
        </div>

        <div class="mx-auto">
            <small id="msgHelp" class="form-text text-muted">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </small>
        </div>
        <div class="w-100">
            <asp:LinkButton runat="server" id="btnResetPw" CssClass="btn btn-primary w-100" OnClick="btnResetPw_Click" Text="Reset password"></asp:LinkButton>
        </div>
        <div class="mx-auto">
            <div><a href="Signin.aspx">Back to signin</a></div>
        </div>
</asp:Content>                  