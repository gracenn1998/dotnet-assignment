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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        FinalProject.Data.Account acc = new FinalProject.Data.Account();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPw_Click(object sender, EventArgs e)
        {
            acc.email = txtEmail.Text;
            DataRow dr = new AccountDataManager().getAccount(acc.email);
            if (dr!=null)
            {
                acc.id = int.Parse(dr["id"].ToString());
                Token token = new Token();
                new AccountDataManager().setToken(acc, token);
                sendResetPasswordEmail(acc.id, token.token);

                lblMessage.Text = "Reset password request was sent by email. Please check your mailbox to continue";
                lblMessage.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblMessage.Text = "This email does not exist";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            
        }
        public void sendResetPasswordEmail(int userid, string token)
        {
            string serverhost = "https://localhost:44315/";
            EmailHelper helper = new EmailHelper();
            helper.setCredential();

            String activateUrl = serverhost + "Account/ResetPassword?userid="
                                + userid + "&token=" + token;
            string subject = "[TimetableApp] Reset Password";
            string body = "Dear Mr/Ms. " + acc.email + ","
                + "<br /><br />Please click the following link to reset your password"
            + "<br /><a href = '" + activateUrl + "'>Click here to reset your password.</a>"
            + "<br /><br />Best regards";

            helper.setMessage("n240398@gmail.com", acc.email, subject, body, true);
            helper.sendMessage();

        }
    }
}