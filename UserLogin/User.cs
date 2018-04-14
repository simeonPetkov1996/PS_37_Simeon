using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public String username { get; set; }
        public String password { get; set; }
        public String number { get; set; }
        public int role { get; set; }
        public DateTime created { get; set; }
        public DateTime activeTo { get; set; }

        public User(String username, String password, String number, int role, DateTime created, DateTime activeTo)
        {
            this.username = username;
            this.password = password;
            this.number = number;
            this.role = role;
            this.created = created;
            this.activeTo = activeTo;
        }
    }
}
