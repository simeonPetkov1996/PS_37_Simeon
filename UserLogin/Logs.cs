using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class Logs
    {
        public int LogsId { get; set; }
        public string msg { get; set; }

        public Logs(string msg)
        {
            this.msg = msg;
        }

        public Logs()
        {

        }
    }
}
