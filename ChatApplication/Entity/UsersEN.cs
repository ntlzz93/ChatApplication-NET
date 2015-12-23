using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace ChatApplication
{
    public class UsersEN
    {
        public UsersEN()
        {

        }
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? Status { get; set; }

        public void setValue(User Us)
        {
            this.ID = Us.ID;
            this.Username = Us.Username;
            this.Password = Us.Password;
            this.Email = Us.Email;
            this.Status = Us.Status;
        }

    }
}
