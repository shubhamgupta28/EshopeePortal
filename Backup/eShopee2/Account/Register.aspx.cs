using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShopee2.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Classes.Validation objValidate = new Classes.Validation();
            bool error = false;
            litError.Text = "";

            if (!objValidate.isValidName(txtName.Text.ToString()))
            {
                error = true;
                litError.Text += "Invalid Name<br>";
            }

            if (!objValidate.isValidEmail(txtEmail.Text.ToString()))
            {
                error = true;
                litError.Text += "Invalid Email Address<br>";
            }

            if (!objValidate.isValidPassword(txtPassword.Text.ToString()))
            {
                error = true;
                litError.Text += "Invalid Password<br>";
            }

            if (txtPassword.Text.ToString() != txtRePassword.Text.ToString())
            {
                error = true;
                litError.Text += "Passwords do not match<br>";   
            }

            if (error)
                return;        

            Classes.User objUser = new Classes.User();

            if (objUser.addUser(txtName.Text.ToString(), txtEmail.Text.ToString(), txtPassword.Text.ToString(), null, "Customer"))
            {
                string activationCode = objUser.getActivationCode(txtEmail.Text.ToString());

                string activationLink = "http://" + Request.Url.Authority + "/Account/Activate.aspx?code=" + activationCode + "&email=" + txtEmail.Text.ToString(); ;

                string activationMessage = "Hello " + txtName.Text.ToString() + ",<br><br>";
                activationMessage += "Please activate your account by clicking on the link:<br><br>";
                activationMessage += activationLink;

                Classes.Mail objMail = new Classes.Mail(txtEmail.Text.ToString(), "eShopee Account Activation", activationMessage);

                litError.Text = "You are successfully registered";

            }

            else
                litError.Text = "Your account could not be registered";

            objUser.close();

        }
    }
}