using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eShopee2.Classes
{
    public class Validation
    {
        // Regular Expressions

        /*
         * ^    : Start of Line
         * $    : End of Line
         * ()   : Sub-string
         * []   : Allowed characters
         * {}   : Length specification
         *          
         */

        public bool isValidUsername(string username)
        {
            /*
             * Should start from character
             * Length between 6-10
             * Could carry a-z, 0-9, _
             * 
             * ^([a-z]{1})([a-z0-9_]{5,9})$
             */

            if (!string.IsNullOrEmpty(username) &&
                    System.Text.RegularExpressions.Regex.IsMatch(username, "^([a-z]{1})([a-z0-9_]{5,9})$"))
                return true;
            else
                return false;
            
        }
                
        public bool isValidAlpha(string data)
        {
            string pattern = "^([a-zA-Z]+)$";
            return validate(data, pattern);
        }

        public bool isValidName(string name)
        {
            string pattern = @"^([\.a-zA-Z ]+)$";
            return validate(name, pattern);
        }

        public bool isValidEmail(string email)
        {
            string pattern = @"@([a-zA-Z0-9\-]+)\.([a-zA-Z\.]+)$";
            return validate(email, pattern);
        }

        public bool isValidPassword(string password)
        {
            if (validate(password, "([A-Z]+)") &&
                validate(password, "([a-z]+)") &&
                validate(password, "([0-9]+)") &&
                validate(password, @"([\@#<>]+)") &&
                password.Length > 5
                )
                return true;
            else
                return false;
        }


        private bool validate(string data, string pattern)
        {
            if (!string.IsNullOrEmpty(data) &&
                    System.Text.RegularExpressions.Regex.IsMatch(data, pattern))
                return true;
            else
                return false;
        }

    }
}