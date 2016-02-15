using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShopee2.Account
{
    public partial class Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.Auth objAuth = new Classes.Auth();
            objAuth.isLoggedIn();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Classes.User objUser = new Classes.User();
            Classes.Cryptography objCrypto = new Classes.Cryptography();
            Classes.Validation objValidate = new Classes.Validation();

            try
            {
                string email = Session["username"].ToString();
                string oldPassword = txtOldPassword.Text.ToString();
                string newPassword = txtNewPassword.Text.ToString();
                bool error = false;

                if (objUser.getPassword(email) != objCrypto.genPassHash(oldPassword))
                {
                    error = true;
                    litError.Text += "Incorrect Old Password<br>";
                }

                if (!objValidate.isValidPassword(newPassword))
                {
                    error = true;
                    litError.Text = "Invalid New Password";
                }

                if (newPassword != txtConfNewPassword.Text.ToString())
                {
                    error = true;
                    litError.Text = "Passwords Do Not Match";
                }

                if (error)
                    return;

                if (objUser.setPassword(email, newPassword))
                {
                    litError.Text = "Password Updated Successfully";
                }
            }

            catch (Exception ex)
            {
                litError.Text = "Password Could Not Be Updated";
            }

            objUser.close();


        }


    }
}