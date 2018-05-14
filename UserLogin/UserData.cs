using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _defaultUsers;
            }

            set
            {
            }
        }

        private static List<User> _defaultUsers;


        static private void ResetTestUserData()
        {
            _defaultUsers = new List<User>();
            _defaultUsers.Add(new User("123456", "123456", "121215078", 2, DateTime.Now, DateTime.MaxValue));
            _defaultUsers.Add(new User("1234567", "1234567", "121215078", 4, DateTime.Now, DateTime.MaxValue));
            _defaultUsers.Add(new User("Gosho11", "Gosho123", "1212121213", 4, DateTime.Now, DateTime.MaxValue));
            _defaultUsers.Add(new User("Simo11", "Simo123", "1212121214", 4, DateTime.Now, DateTime.MaxValue));
            _defaultUsers.Add(new User("Ivan11", "Ivan123", "1212121215", 4, DateTime.Now, DateTime.MaxValue));
            _defaultUsers.Add(new User("Kiro11", "Kiro123", "121212121216", 4, DateTime.Now, DateTime.MaxValue));
        }

        public static void AssignUserRole(int id, UserRoles role)
        {
            UserContext context = new UserContext();
            User user = context.Users.ElementAt(id);

            user.role = (int)role;
            Logger.LogActivity(Activities.USER_ROLE_CHANGED);
            Console.WriteLine(user.username);
            Console.WriteLine(user.password);
            Console.WriteLine(user.number);
            Console.WriteLine((UserRoles)user.role);
            Console.WriteLine(user.created);
            Console.WriteLine(user.activeTo);
            context.SaveChanges();
            return;

        }


        public static void SetUserActiveTo(int id, DateTime expirationDate)
        {
            UserContext context = new UserContext();
            User user = context.Users.ElementAt(id);

            user.activeTo = expirationDate;
            Logger.LogActivity(Activities.USER_ACTIVE_TO_CHANGED);
            Console.WriteLine(user.username);
            Console.WriteLine(user.password);
            Console.WriteLine(user.number);
            Console.WriteLine((UserRoles)user.role);
            Console.WriteLine(user.created);
            Console.WriteLine(user.activeTo);
            return;


        }

        static public Dictionary<string, int> AllUsersUsernames()
        {
            UserContext context = new UserContext();
            Dictionary<string, int> result = new Dictionary<string, int>();
            IEnumerable<User> Users = context.Users;
            for (int i = 0; i < Users.Count(); i++)
            {
                result.Add(Users.ElementAt(i).username, i);
            }
            return result;
        }
    }
}
