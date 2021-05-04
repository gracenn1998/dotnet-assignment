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
    public partial class Activate : System.Web.UI.Page
    {
        FinalProject.Data.Account acc = new FinalProject.Data.Account();
        String param_token;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request["token"]==null || Request["userid"]==null)
            {
                lblTitle.Text = "Invalid information";
                lblMessage.Text = "If you are trying to activate your account, it seems that your token has been expired.";
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
            DataRow dr = new AccountDataManager().getToken(acc);
            if (dr != null)
            {
                Token token = new Token();
                token.token = dr["token"].ToString();
                token.expireTime = DateTime.Parse(dr["expiretime"].ToString());

                int status = token.validateToken(param_token);
                if (status == 1) //valid token
                {
                    new AccountDataManager().activateAccount(acc);
                    lblTitle.Text = "Activated successfully.";
                    lblMessage.Text = "Please login <a href=\"/Account/Signin.aspx\">here</a>";
                }
                else 
                {
                    lblTitle.Text = "Invalid information";
                    lblMessage.Text = "If you are trying to activate your account, it seems that your token has been expired.";
                }
            }
            else
            {
                lblTitle.Text = "Invalid information";
                lblMessage.Text = "If you are trying to activate your account, it seems that your token has been expired.";
            }
        }
    }
}