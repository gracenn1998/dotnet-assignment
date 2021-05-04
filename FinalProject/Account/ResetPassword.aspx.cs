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
    public partial class ResetPassword : System.Web.UI.Page
    {
        FinalProject.Data.Account acc = new FinalProject.Data.Account();
        String param_token;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["token"] == null || Request["userid"] == null)
            {
                divInvalid.Visible = true;
                divResetPassword.Visible = false;
            }
            else
            {
                param_token = Request["token"];
                acc.id = int.Parse(Request["userid"]);
                loadData();
            }
        }

        protected void loadData()
        {
            divResetPassword.Visible = true;
            divInvalid.Visible = false;
            DataRow dr = new AccountDataManager().getToken(acc);
            if (dr != null)
            {
                divResetPassword.Visible = true;
                divInvalid.Visible = false;

                Token token = new Token();
                token.token = dr["token"].ToString();
                token.expireTime = DateTime.Parse(dr["expiretime"].ToString());

                int status = token.validateToken(param_token);
                if (status == 1) //valid token
                {
                    lblMessage.ForeColor = System.Drawing.Color.Black;
                    lblMessage.Text = "Please enter your new password";
                }
                else //expired token
                {
                    divResetPassword.Visible = false;
                    divInvalid.Visible = true;
                }
            }
            else
            {
                divResetPassword.Visible = false;
                divInvalid.Visible = true;
            }
            
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            acc.changePassword(txtPassword.Text);
            new AccountDataManager().updateAccount(acc);
            lblMessage.Text = "Reset password successfully. " +
                        "Please login <a href=\"/Account/Signin.aspx\">here</a>";
        }


    }
}