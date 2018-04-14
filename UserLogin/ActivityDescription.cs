using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class ActivityDescription
    {
        public static Dictionary<Activities, String> ActivityToDescription
        {
            get
            {
                ResetActivityToDescription();
                return _activityToDescription;
            }

            set
            {
            }
        }

        private static Dictionary<Activities, String> _activityToDescription;


        static private void ResetActivityToDescription()
        {
            _activityToDescription = new Dictionary<Activities, String>();
            _activityToDescription.Add(Activities.USER_LOGIN, "User {0} with role {1} login.");
            _activityToDescription.Add(Activities.USER_ROLE_CHANGED, "User {0} with role {1} changed role.");
            _activityToDescription.Add(Activities.USER_ACTIVE_TO_CHANGED, "User {0} with role {1} changed active to.");
        }
    }
}
