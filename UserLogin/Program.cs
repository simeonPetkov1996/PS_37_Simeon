using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class Program
    {
        static void Main(string[] args)
        {
            String username = Console.ReadLine();
            String password = Console.ReadLine();
            LoginValidation loginValidation = new LoginValidation(username, password, new LoginValidation.ActionOnError(logErrorToConsole)) ;
            User user = new User("", "", "", 5, DateTime.Now, DateTime.Now);
            if (loginValidation.ValidateUserInput(ref user))
            {
                Console.WriteLine(user.username);
                Console.WriteLine(user.password);
                Console.WriteLine(user.number); 
                Console.WriteLine((UserRoles)user.role);
                Console.WriteLine(user.created);
                Console.WriteLine(user.activeTo);
            }

            if (user.role == (int)UserRoles.ADMIN)
            {
                Program.openAdminMenu();
            }
            Console.ReadLine();
        }

        private static void logErrorToConsole(String message)
        {
            Console.WriteLine(message);
        }

        private static void openAdminMenu()
        {
            int command = -1;
            string input;
            DateTime dateTime;
            UserRoles userRole;
            Dictionary<string, int> allusers = UserData.AllUsersUsernames();
            do
            {
                Console.WriteLine("Изберете опция:" +
                    "\r\n" + "0:Изход" + "\r\n" + "1:Промяна на роля на потребител" + "\r\n" + "2:Промяна на активност на потребител"
                     + "\r\n" + "3:Списък на потребители" + "\r\n" + "4:Преглед на лог активност" + "\r\n" + "5:Преглед на текущата активност");
                command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        foreach (KeyValuePair<string, int> usernameToId in allusers)
                        {
                            Console.WriteLine(usernameToId.Key);
                        }
                        Console.WriteLine("Въведете името на потребителя");
                        input = Console.ReadLine();
                        Console.WriteLine("Въведете новата роля");
                        userRole = (UserRoles)Convert.ToInt32(Console.ReadLine());
                        UserData.AssignUserRole(allusers[input], userRole);
                        break;
                    case 2:
                        foreach (KeyValuePair<string, int> usernameToId in allusers)
                        {
                            Console.WriteLine(usernameToId.Key);
                        }
                        Console.WriteLine("Въведете името на потребителя");
                        input = Console.ReadLine();
                        Console.WriteLine("Въведете новата активност на потребителя");
                        dateTime = DateTime.Parse(Console.ReadLine());
                        UserData.SetUserActiveTo(allusers[input], dateTime);
                        break;
                    case 3:
                        foreach(KeyValuePair<string, int> usernameToId in UserData.AllUsersUsernames())
                        {
                            Console.WriteLine(usernameToId.Key);
                        }
                        break;
                    case 4:
                        Console.WriteLine(File.ReadAllText("test.txt"));
                        break;
                    case 5:
                        Console.WriteLine("Въведете филтър за логовете");
                        input = Console.ReadLine();
                        Console.WriteLine(Logger.getCurrentSessionActivities(input));
                        break;

                }
            } while (command != 0);

        }
    }
}
