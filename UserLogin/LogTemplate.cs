using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LogTemplate
    {
        public Activities activity { get; set; }
        public String username { get; set; }
        public UserRoles userRole { get; set; }

        public LogTemplate(Activities activity, string username, UserRoles userRole)
        {
            this.activity = activity;
            this.username = username;
            this.userRole = userRole;
        }

        override
        public string ToString()
        {
            return String.Format(ActivityDescription.ActivityToDescription[activity], username, userRole.ToString());
        }
    }
}
