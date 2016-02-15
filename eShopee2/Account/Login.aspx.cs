using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShopee2.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.ToString();
                string password = txtPassword.Text.ToString();
                bool error = false;
                litError.Text = "";

                Classes.Validation objValidate = new Classes.Validation();

                if (!objValidate.isValidEmail(email))
                {
                    error = true;
                    litError.Text += "Invalid Email Address<br>";
                }

                if (!objValidate.isValidPassword(password))
                {
                    error = true;
                    litError.Text += "Invalid Password<br>";
                }

                if (error)
                    return;

                Classes.Cryptography crypto = new Classes.Cryptography();

                password = crypto.genPassHash(password);

                Classes.User objUser = new Classes.User();

                if (password == objUser.getPassword(email))
                {
                    Session["username"] = email;
                    Session["loggedIn"] = "true";
                    Session["role"] = objUser.getRole(email);

                    Response.Redirect("Dashboard.aspx");
                }

                else
                {
                    litError.Text = "Invalid Account Login Information Provided";
                }
            }

            catch (Exception ex)
            {
                litError.Text = "Invalid Account Login Information Provided";
            }
        }
    }
}