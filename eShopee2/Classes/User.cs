using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace eShopee2.Classes
{
    public class User : Database
    {
        public bool addUser(string name, string email, string password, string mobile, string role)
        {
            Classes.Cryptography crypto = new Classes.Cryptography();

            password = crypto.genPassHash(password);
            string activationCode = genActivationCode();
            int effectedRows = setData("insert into users (name, email, password, mobile, role, status, activationcode) values('" + name + "','" + email + "','" + password + "','" + mobile + "','" + role + "','Inactive','" + activationCode + "')");

            if (effectedRows == 1)
                return true;

            return false;

        }

        private string genActivationCode()
        {
            return Guid.NewGuid().ToString();
        }

        public string getActivationCode(string email)
        {
            SqlDataReader dataSet = getData("select activationCode from users where email='" + email + "'");
            if (dataSet.HasRows)
            {
                dataSet.Read();
                string activationCode = dataSet["activationCode"].ToString();
                dataSet.Close();
                return activationCode;
            }

            return null;
        }

        public bool setActivationCode(string email)
        {
            string activationCode = genActivationCode();

            int effectedRows = setData("update users set activationCode='" + activationCode + "' where email='" + email + "'");

            if (effectedRows == 1)
                return true;

            return false;
        }

        public bool setStatus(string email, string status)
        {
            int effectedRows = setData("update users set status='" + status + "' where email='" + email + "'");

            if (effectedRows == 1)
                return true;

            return false;
        }

        public string getPassword(string email)
        {
            SqlDataReader dataSet = getData("select password from users where email='" + email + "'");
            if (dataSet.HasRows)
            {
                dataSet.Read();
                string password = dataSet["password"].ToString();
                dataSet.Close();
                return password;
            }

            return null;
        }

        public bool setPassword(string email, string password)
        {
            int effectedRows = setData("update users set password='" + password + "' where email='" + email + "'");

            if (effectedRows == 1)
                return true;

            return false;
        }

        public SqlDataReader getUser(string searchField, string searchValue, string searchField2=null, string searchValue2=null)
        {
            string query = "select * from users where "+searchField+"='"+searchValue+"'";

            if (!string.IsNullOrEmpty(searchField2) && !string.IsNullOrEmpty(searchValue2))
                query += " and " + searchField2 + "='" + searchValue2 + "'";

            SqlDataReader dataset = getData(query);

            if (dataset.HasRows)
                return dataset;

            return null;
        }

        public bool setUser(string name, string email, string mobile)
        {
            int effectedRows = setData("update users set name='"+name+"', mobile='"+mobile+"' where email='"+email+"'");

            if (effectedRows == 1)
                return true;

            return false;
        }

        public string getProfilePic(string email)
        {
            SqlDataReader dataSet = getData("select profilePic from users where email='" + email + "'");
            if (dataSet.HasRows)
            {
                dataSet.Read();
                string profilePic = dataSet["profilePic"].ToString();
                dataSet.Close();
                return profilePic;
            }

            return null;
        }

        public bool setprofilePic(string email, string profilePic)
        {
            int effectedRows = setData("update users set profilePic='" + profilePic + "' where email='" + email + "'");

            if (effectedRows == 1)
                return true;

            return false;
        }

        public bool addAddress(string address1, string address2, string city, string state, string country, string pincode, string isDefault, string email)
        {
            int effectedRows = setData("insert into addresses (email, address1, address2, city, state, country, pincode, isdefault) values('" + email + "','" + address1 + "','" + address2 + "','" + city + "','" + state + "','" + country + "','" + pincode + "','" + isDefault + "')");

            if (effectedRows == 1)
                return true;

            return false; 
        }

        public SqlDataReader getAddress(string searchField, string searchValue, string searchField2 = null, string searchValue2 = null)
        {
            string query = "select * from addresses where " + searchField + "='" + searchValue + "'";

            if (!string.IsNullOrEmpty(searchField2) && !string.IsNullOrEmpty(searchValue2))
                query += " and " + searchField2 + "='" + searchValue2 + "'";

            SqlDataReader dataset = getData(query);

            if (dataset.HasRows)
                return dataset;

            return null;
        }
         
        public bool setAddress(int id, string address1, string address2, string city, string state, string country, string pincode, string isdefault, string email)
        {
            int effectedRows = setData("update addresses set address1='"+address1+"', address2='"+address2+"', city='"+city+"', state='"+state+"', country='"+country+"', pincode='"+pincode+"', isdefault='"+isdefault+"' where id="+id+" and email='"+email+"'");

            if (effectedRows == 1)
                return true;

            return false;
        }

        public string getRole(string email)
        {
            SqlDataReader dataSet = getData("select role from users where email='" + email + "'");
            if (dataSet.HasRows)
            {
                dataSet.Read();
                string role = dataSet["role"].ToString();
                dataSet.Close();
                return role;
            }

            return null;
        }

        public bool setRole(string email, string role)
        {
            int effectedRows = setData("update users set role='" + role + "' where email='" + email + "'");

            if (effectedRows == 1)
                return true;

            return false;
        }



    }
}








