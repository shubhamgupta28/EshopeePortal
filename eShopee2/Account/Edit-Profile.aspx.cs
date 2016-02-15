using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eShopee2.Account
{
    public partial class Edit_Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.Auth objAuth = new Classes.Auth();
            objAuth.isLoggedIn();

            if (IsPostBack)
                return;
            
            Classes.User objUser = new Classes.User();
            
            
            try
            {
                SqlDataReader userData = objUser.getUser("email", Session["username"].ToString());

                if (userData != null)
                {
                    userData.Read();
                    litEmail.Text = userData["email"].ToString();
                    txtName.Text = userData["name"].ToString();
                    txtMobile.Text = userData["mobile"].ToString();
                }
            }

            catch (Exception ex)
            {

            }

            objUser.close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Classes.User objUser = new Classes.User();
            
            try
            {
                string email = Session["username"].ToString();
                string name = txtName.Text.ToString();
                string mobile = txtMobile.Text.ToString();

                Classes.Validation objValidate = new Classes.Validation();
                bool error = false;
                litError.Text = "";

                if (!objValidate.isValidName(name))
                {
                    error = true;
                    litError.Text = "Invalid Name";
                }

                if (error)
                    return;

                if (objUser.setUser(name, email, mobile))
                {
                    litError.Text = "Account Updated Successfully";
                }


                   
            }

            catch (Exception ex)
            {
                litError.Text = "Account Could Not be Updated";
            }

            objUser.close();
        }
    }
}