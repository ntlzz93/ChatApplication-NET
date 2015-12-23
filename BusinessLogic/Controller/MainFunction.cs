using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Windows.Forms;

namespace BusinessLogic
{
    public class MainFunction
    {
        private DbDataContext db = new DbDataContext();
        private UsersBO aUserBO = new UsersBO();
        public MainFunction()
        {

        }
        // Login
        public bool SignIn(string name, string password)
        {
            try
            {

                string passSHA1;
                passSHA1 = ToSHA1(password);
                var user = db.Users.Where(b => b.Username == name).Where(b => b.Password == passSHA1).ToList<User>();
                if (user.Any())
                {
                    
                    return true;
                }
                else
                {
                    
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("UserBO.SignIn()" + ex.ToString());
            }
        }
        // Register
        public bool SignUp(User aUser)
        {
            try
            {
                if (aUserBO.Insert(aUser))
                {
                    
                    return true;
                }
                else
                {
                    
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("UserBO.SignUp()" + ex.ToString());
            }
        }
        // SHA1
        public  string ToSHA1(string pass)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
            bs = sha1.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x1").ToLower());
            }
            pass = s.ToString();
            return pass;
        }
    }
}
