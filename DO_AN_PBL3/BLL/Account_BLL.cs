using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DO_AN_PBL3.BLL
{
    class Account_BLL
    {
        private static Account_BLL _Instance;
        public static Account_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Account_BLL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
       public bool Login_BLL(int username, string password,int type)
        {
            byte[] tempt = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(tempt);
            string hashpass = "";
            foreach(byte item in hashData)
            {
                hashpass += item;
            }
            if (type == 0)
            {
                return DAL.Account_DAL.Instance.Login_DAL(username, hashpass);
            }
            else
            {
                return DAL.Account_DAL.Instance.ResetPassword_DAL(username, hashpass);
            }
        }
       /* public bool ResetPassword(int username, string newpassword)
        {

            byte[] tempt = ASCIIEncoding.ASCII.GetBytes(newpassword);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(tempt);
            string hashpass = "";
            foreach (byte item in hashData)
            {
                hashpass += item;
            }
            return DAL.Account_DAL.Instance.ResetPassword_DAL(username, hashpass);
        }*/
       
    }
}
