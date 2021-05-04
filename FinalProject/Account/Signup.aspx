<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="FinalProject.Account.Signup" %>


<asp:Content ID="Signup" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card p-3 mx-auto mt-3" style="width: 20rem;">
        <h5 class="card-title mx-auto">Sign Up</h5>
        <div class="form-group">
            <asp:TextBox ID="txtEmail" runat="server" style="width:100%;" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
        
            <small id="emailHelp" class="form-text text-muted">
                <asp:RequiredFieldValidator ID="rv_Email" runat="server" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic">Please enter email</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">Invalid Email</asp:RegularExpressionValidator>
            </small>
        </div>

        <div class="form-group">
            <asp:TextBox ID="txtPassword" runat="server" style="width:100%;" TextMode="Password" CssClass="form-control" placeholder="Enter password"></asp:TextBox>
            <small id="passwordHelp" class="form-text text-muted">
                <asp:RequiredFieldValidator ID="rv_Password" runat="server" ControlToValidate="txtPassword" EnableTheming="True" ForeColor="Red" Display="Dynamic">Please enter password</asp:RequiredFieldValidator>
            </small>
        </div>

        <div class="form-group">
            <asp:TextBox ID="txtCfmPassword" runat="server" style="width:100%;" TextMode="Password" CssClass="form-control" placeholder="Enter password"></asp:TextBox>
            <small id="cfmPasswordHelp" class="form-text text-muted">
                <asp:CompareValidator ID="cv_CfmPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtCfmPassword" ErrorMessage="Confirm password does not match" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="rv_CfmPassword" runat="server" ControlToValidate="txtCfmPassword" EnableTheming="True" ForeColor="Red" Display="Dynamic">Please enter confirm password</asp:RequiredFieldValidator>
            </small>
        </div>

        <div class="mx-auto">
            <small id="msgHelp" class="form-text text-muted">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </small>
        </div>
        <div class="w-100">
            <asp:LinkButton runat="server" id="_btnSignup" CssClass="btn btn-primary w-100" OnClick="_btnSignup_Click" Text="Sign up"></asp:LinkButton>
        </div>
        <div class="mx-auto">
            <div>Already had an account? <a href="Signin.aspx">Sign in</a></div>
        </div>
    </div>
    
</asp:Content>