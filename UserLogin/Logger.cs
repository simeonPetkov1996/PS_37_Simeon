using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
        static private List<LogTemplate> currentSessionActivities = new List<LogTemplate>();

        static public void LogActivity(Activities activity)
        {
            LogTemplate logTemplate = new LogTemplate(activity, LoginValidation.currentUserUsername, LoginValidation.UserRole);
            currentSessionActivities.Add(logTemplate);
            if (File.Exists("test.txt"))
            {
                File.AppendAllText("test.txt", logTemplate.ToString() + "\n");
            }
        }

        static public string getCurrentSessionActivities(String filter)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(String str in (from activity in currentSessionActivities
                                  where activity.ToString().Contains(filter)
                                  select activity.ToString()).ToList())
            {
                stringBuilder.AppendLine(str);
            }
            return stringBuilder.ToString();
        }
    }
}
