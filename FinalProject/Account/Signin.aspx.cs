using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.Data;

namespace FinalProject.Account
{
    public partial class Signin : System.Web.UI.Page
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

        protected void _btnSignin_Click(object sender, EventArgs e)
        {
            acc.email = txtEmail.Text;
            string password = txtPassword.Text;

            DataRow dr = new AccountDataManager().getAccount(acc.email);
            if (dr == null)
            {
                lblMessage.Text = "This email does not exist.";
            }
            else
            {
                acc.email = dr["email"].ToString();
                acc.hashed_password = dr["password"].ToString();
                acc.salt = dr["salt"].ToString();
                if (acc.validatePassword(password))
                {
                    Response.Cookies["userid"].Value = dr["id"].ToString();
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(14);
                    Response.Redirect("/");
                }
                else
                {
                    lblMessage.Text = "Wrong email or password.";
                }
            }
            
        }
    }
}