using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopee2.Classes
{
    public class Auth
    {
        System.Web.SessionState.HttpSessionState Session = HttpContext.Current.Session;
        HttpResponse Response = HttpContext.Current.Response;
        HttpRequest Request = HttpContext.Current.Request;

        public void isLoggedIn()
        {
            try
            {
                if (Session["loggedIn"].ToString() != "true")
                    Response.Redirect("http://" + Request.Url.Authority + "/Account/Login.aspx");
            }

            catch
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Account/Login.aspx");
            }
        }

        public void isAdmin()
        {
            try
            {
                isLoggedIn();
                if (Session["role"].ToString() != "Admin")
                    Response.Redirect("http://" + Request.Url.Authority + "/Not-Authorized.aspx");
            }

            catch
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Not-Authorized.aspx");
            }
        }


    }
}