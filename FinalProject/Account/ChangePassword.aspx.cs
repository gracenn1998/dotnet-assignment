using FinalProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private FinalProject.Data.Account acc = new FinalProject.Data.Account();
        private String currentPassword, newPassword;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userid"] == null)
            {
                Response.Redirect("~/Account/Signin.aspx");
            }
            else
            {
                acc.id = int.Parse(Request.Cookies["userid"].Value);
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            currentPassword = txtCurPassword.Text;
            newPassword = txtPassword.Text;

            DataRow dr = new AccountDataManager().getAccount(acc.id);
            acc.email = dr["email"].ToString();
            acc.hashed_password = dr["password"].ToString();
            acc.salt = dr["salt"].ToString();
            if (acc.validatePassword(currentPassword))
            {
                acc.changePassword(newPassword);
                new AccountDataManager().updateAccount(acc);
                lblMessage.Text = "Changed password successfully";
                lblMessage.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblMessage.Text = "Incorrect current password";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}