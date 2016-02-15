using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShopee2.Account
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.Auth objAuth = new Classes.Auth();
            objAuth.isLoggedIn();
            
            litName.Text = Session["username"].ToString();
        }
    }
}