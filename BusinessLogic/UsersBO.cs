using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class UsersBO
    {
        public UsersBO()
        {

        }

        private DbDataContext db = new DbDataContext();
        // Select 
        public List<User> SelectAll()
        {
            try
            {
                return db.Users.ToList<User>();
            }
            catch (Exception ex)
            {
                throw new Exception("UserBO.SelectAll" + ex.ToString());
            }
        }
        // Select by ID
        public List<User> Select_ByID(int ID)
        {
            try
            {
                return db.Users.Where(b => b.ID == ID).ToList<User>();
            }
            catch (Exception ex)
            {
                throw new Exception("UserBO.Select_ByID" + ex.ToString());
            }
        }
        // Insert
        public bool Insert(User aUser)
        {
            try
            {
                MainFunction mF = new MainFunction();
                string password = mF.ToSHA1(aUser.Password);
                db.Users.InsertOnSubmit(aUser);
                db.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("UserBO.Insert" + ex.ToString());
            }

        }
    }
}
