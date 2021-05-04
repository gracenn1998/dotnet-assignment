<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="FinalProject.Account.Signin" %>

<asp:Content ID="Signin" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card p-3 mx-auto mt-3" style="width: 20rem;">
        <h5 class="card-title mx-auto">Sign In</h5>
        <div class="form-group">
            <asp:TextBox ID="txtEmail" runat="server" style="width:100%;" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
        
            <small id="emailHelp" class="form-text text-muted">
                <asp:RequiredFieldValidator ID="rv_Email" runat="server" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic">Please enter email</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_Email" runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">Invalid Email</asp:RegularExpressionValidator>
            </small>
        </div>

        <div class="form-group">
            <asp:TextBox ID="txtPassword" runat="server" style="width:100%;" TextMode="Password" CssClass="form-control" placeholder="Enter password"></asp:TextBox>
            <small id="passwordHelp" class="form-text text-muted">
                <asp:RequiredFieldValidator ID="rv_Password" runat="server" ControlToValidate="txtPassword" EnableTheming="True" ForeColor="Red" Display="Dynamic">Please enter password</asp:RequiredFieldValidator>
            </small>
            <a href="ForgotPassword.aspx">Forgot password?</a>
        </div>

        <div class="mx-auto">
            <small id="msgHelp" class="form-text text-muted">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </small>
        </div>
        <div class="w-100">
            <asp:LinkButton runat="server" id="_btnSignin" CssClass="btn btn-primary w-100" OnClick="_btnSignin_Click" Text="Sign In"></asp:LinkButton>
        </div>
        <div class="mx-auto">
            <div>Do not have an account? <a href="Signup.aspx">Sign up</a></div>
        </div>
    </div>
    
</asp:Content>