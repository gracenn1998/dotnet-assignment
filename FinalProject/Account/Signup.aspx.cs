using FinalProject.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject.Account
{
    public partial class Signup : System.Web.UI.Page
    {
        FinalProject.Data.Account acc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userid"] == null)
            {
                acc = new FinalProject.Data.Account(); 
            }
            else
            {
                Response.Redirect("/");
            }
        }

        protected void _btnSignup_Click(object sender, EventArgs e)
        {
            acc.email = txtEmail.Text;

            if(!new AccountDataManager().doesEmailExist(acc.email))
            {
                acc.changePassword(txtPassword.Text);
                acc.id = new AccountDataManager().createAccount(acc);
                
                Token token = new Token();
                new AccountDataManager().setToken(acc, token);

                sendActivationEmail(acc.id, token.token);

                lblMessage.Text = "Signed up successfully. Please check your mailbox to activate your account";
                lblMessage.ForeColor = System.Drawing.Color.Blue;
                Response.Cookies["userid"].Value = acc.id.ToString();
                //Response.Redirect("~/TimetablePages/Timetable.aspx");
            }
            else
            {
                lblMessage.Text = "This email has already existed. Please try another one.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void refresh()
        {
            txtCfmPassword.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            lblMessage.Text = "";
        }

        public void sendActivationEmail(int userid, string token)
        {
            string serverhost = "https://localhost:44315/";
            EmailHelper helper = new EmailHelper();
            helper.setCredential();

            String activateUrl = serverhost + "Account/ActivateAccount?userid="
                                + userid + "&token=" + token;
            string subject = "[TimetableApp] Account Activation";
            string body = "Dear Mr/Ms. " + acc.email + ","
                + "<br /><br />Please click the following link to activate your account"
            + "<br /><a href = '" + activateUrl + "'>Click here to activate your account.</a>"
            + "<br /><br />Best regards";

            helper.setMessage("n240398@gmail.com", acc.email, subject, body, true);
            helper.sendMessage();

        }
    }
}