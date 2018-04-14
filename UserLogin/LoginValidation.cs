using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private String username;
        private String password;
        private String message;
        private ActionOnError actionOnError;

        public static UserRoles UserRole
        {
            get;
            private set;
        }

        public static string currentUserUsername
        {
            get;
            private set;
        }

        public LoginValidation(String username, String password, ActionOnError actionOnError)
        {
            this.username = username;
            this.password = password;
            this.actionOnError = actionOnError;
        }

        public delegate void ActionOnError(string errorMsg);

        public bool ValidateUserInput(ref User user)
        {
            if (String.IsNullOrEmpty(username))
            {
                message = "empty username";
                actionOnError(message);
                UserRole = UserRoles.ANONYMOUS;
                return false;
            }
            if (String.IsNullOrEmpty(password))
            {
                message = "empty password";
                actionOnError(message);
                UserRole = UserRoles.ANONYMOUS;
                return false;
            }
            if (username.Length <= 5)
            {
                message = "username less then 5 characters";
                actionOnError(message);
                UserRole = UserRoles.ANONYMOUS;
                return false;
            }
            if (password.Length <= 5)
            {
                message = "password less then 5 characters";
                actionOnError(message);
                UserRole = UserRoles.ANONYMOUS;
                return false;
            }
            User authorizedUser = IsUserPassCorrect(username, password);
            if (authorizedUser == null)
            {
                message = "unauthorized user";
                actionOnError(message);
                UserRole = UserRoles.ANONYMOUS;
                return false;
            }
            UserRole = (UserRoles)authorizedUser.role;
            user = authorizedUser;
            currentUserUsername = user.username;
            Logger.LogActivity(Activities.USER_LOGIN);
            return true;
        }

        private User IsUserPassCorrect(String username, String password)
        {
            List<User> users = (from user in UserData.TestUsers
                                where user.username.Equals(username) && user.password.Equals(password)
                                select user).ToList();
            return users.Count == 0 ? null : users.First();
        }
    }
}
