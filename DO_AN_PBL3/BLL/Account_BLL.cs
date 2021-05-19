using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DO_AN_PBL3.Entity;
using DO_AN_PBL3.DAL;

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
        public bool Login_BLL(int username, string password, int type)
        {
            byte[] tempt = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(tempt);
            string hashpass = "";
            foreach (byte item in hashData)
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

        public NHANVIEN GetNVByID(int id)
        {
            return Account_DAL.Instance.GetNVByID(id);
        }

    }
}