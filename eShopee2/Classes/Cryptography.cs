using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace eShopee2.Classes
{
    public class Cryptography
    {
        public string genMD5(string plainText)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(plainText);
            MD5 md5 = new MD5CryptoServiceProvider();
            return genString(md5.ComputeHash(data));
        }

        public string genSHA1(string plainText)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(plainText);
            SHA1 sha = new SHA1CryptoServiceProvider();
            return genString(sha.ComputeHash(data));
        }

        public string genSHA256(string plainText)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(plainText);
            SHA256 sha = new SHA256CryptoServiceProvider();
            return genString(sha.ComputeHash(data));
        }

        public string genSHA512(string plainText)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(plainText);
            SHA512 sha = new SHA512CryptoServiceProvider();
            return genString(sha.ComputeHash(data));
        }

        private string genString(byte[] byteText)
        {
            string str = "";
            foreach (byte x in byteText)
                str += String.Format("{0:x2}", x);
            return str;
        }

        public string genPassHash(string Password)
        {
            Password += genMD5(Password);
            return genMD5(Password);
        }
    }
}