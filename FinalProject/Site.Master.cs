using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userid"]== null || Request.Cookies["userid"].Expires < DateTime.Now)
            {
                divSignin.Visible = true;
                divSignout.Visible = false;
            }
            else
            {
                divSignin.Visible = false;
                divSignout.Visible = true;
                System.Diagnostics.Debug.WriteLine(Request.Cookies["userid"].Value);
            }
        }

        protected void BtnSignout_Click(object sender, EventArgs e)
        {
            Request.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
        }

        protected void BtnSignin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Signin.aspx");
        }

        protected void BtnSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Account/Signup.aspx");
        }
    }
}