using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eShopee2.Account
{
    public partial class View_Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.User objUser = new Classes.User();
            Classes.Auth objAuth = new Classes.Auth();
            objAuth.isLoggedIn();

            try
            {
                SqlDataReader userData = objUser.getUser("email", Session["username"].ToString());

                if (userData != null)
                {
                    userData.Read();
                    litEmail.Text = userData["email"].ToString();
                    litName.Text = userData["name"].ToString();
                    litMobile.Text = userData["mobile"].ToString();
                }
            }

            catch (Exception ex)
            { 
                
            }

            objUser.close();
        }
    }
}