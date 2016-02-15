using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShopee2.Account
{
    public partial class Activate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.User objUser = new Classes.User();

            try
            {
                string activationCode = Request["code"].ToString();
                string email = Request["email"].ToString();
                
                if (objUser.getActivationCode(email) == activationCode)
                {
                    objUser.setStatus(email, "Active");
                    litError.Text = "Your account is successfully activated";
                    
                }

                else
                    litError.Text = "Invalid Account Activation Information Provided";

                objUser.close();

            }
            catch(Exception ex)
            {
                litError.Text = "Invalid Account Activation Information Provided";
                objUser.close();
            }

        }
    }
}