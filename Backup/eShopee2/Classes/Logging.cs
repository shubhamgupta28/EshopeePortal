using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopee2.Classes
{
    public class Logging: Database
    {
        // To Countermeasure Repudiation

        System.Web.SessionState.HttpSessionState Session = HttpContext.Current.Session;
        
        public Logging(string action, string onWhich)
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            string performer = Session["username"].ToString();

            string query = "insert into logs (Performer, Action, OnWhich, Time, Location ) values ('" + performer + "', '" + action + "', '" + onWhich + "', GETDATE(), '" + ip + "')";

            setData(query);
            close();
        }
    }
}