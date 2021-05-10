using DO_AN_PBL3.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.DAL
{
    class Account_DAL
    {

        private PBL3_QLTraSuaEntities db;
        private static Account_DAL _Instance;
        public static Account_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Account_DAL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public Account_DAL()
        {
            db = new PBL3_QLTraSuaEntities();
        }
        public bool Login_DAL(int username, string password)
        {
            NHANVIEN s = db.NHANVIENs.Find(username);
            return s.password == password;
        }
        public bool ResetPassword_DAL(int username, string newpassword)
        {

            db = new PBL3_QLTraSuaEntities();
            var s = db.NHANVIENs.Where(p => p.ID_NV == username).FirstOrDefault();
            s.password = newpassword;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
                return false;
            }
          
        }
    }
}

