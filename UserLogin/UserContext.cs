using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Logs> Logger { get; set; }

        public UserContext() : base(Properties.Settings1.Default.DbConnect)
        {

        }
    }
}
