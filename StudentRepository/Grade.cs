using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public class Grade
    {
        public int gradeId { get; set; }
        public int value { get; set; }
        public string subject { get; set; }

        public Grade(int value, string subject)
        {
            this.value = value;
            this.subject = subject;
        }

        public Grade()
        {
            
        }
    }
}
