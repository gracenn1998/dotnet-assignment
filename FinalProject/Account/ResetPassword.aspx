<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="FinalProject.Account.ResetPassword" %>


<asp:Content ID="Reset" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divResetPassword" runat="server">
        <div class="card p-3 mx-auto mt-3" style="width: 20rem;">
            <h5 class="card-title mx-auto">Resset Password</h5>

            <div class="form-group">
                <asp:TextBox ID="txtPassword" runat="server" style="width:100%;" TextMode="Password" CssClass="form-control" placeholder="New password"></asp:TextBox>
                <small id="passwordHelp" class="form-text text-muted">
                     <asp:RequiredFieldValidator ID="rf_Password" runat="server" ControlToValidate="txtPassword" EnableTheming="True" ForeColor="Red" Display="Dynamic">Please enter new password</asp:RequiredFieldValidator>
                </small>
            </div>

            <div class="form-group">
                <asp:TextBox ID="txtCfmPassword" runat="server" style="width:100%;" TextMode="Password" CssClass="form-control" placeholder="Enter password"></asp:TextBox>
                <small id="cfrPasswordHelp" class="form-text text-muted">
                    <asp:CompareValidator ID="cv_CfmPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtCfmPassword" ErrorMessage="Confirm Password does not match" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="rv_CfmPassword" runat="server" ControlToValidate="txtCfmPassword" EnableTheming="True" ForeColor="Red" Display="Dynamic">Please enter confirm password</asp:RequiredFieldValidator>
                </small>
            </div>

            <div class="mx-auto">
                <small id="msgHelp" class="form-text text-muted">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </small>
            </div>
            <div class="w-100">
                 <asp:LinkButton runat="server" id="btnResetPassword" CssClass="btn btn-primary w-100" OnClick="btnResetPassword_Click" Text="Reset password"/>
            </div>
            <div class="mx-auto">
                <div><a href="Signin.aspx">Back to signin</a></div>
            </div>
        </div>
    </div>

    <div id="divInvalid" runat="server" class="jumbotron">
        <h1 class="display-4">Invalid information.</h1>
        <p class="lead">If you are trying to reset password, it seems that your token has been expired.</p>
    </div>
    
    
</asp:Content>
