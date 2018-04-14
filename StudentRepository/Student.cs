using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public class Student
    {
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string lastName { get; set; }
        public string fNumber { get; set; }
        public string faculty { get; set; }
        public string specialty { get; set; }
        public DegreeType degreeType { get; set; }
        public StatusType statusType { get; set; }
        public DateTime lastCertification { get; set; }
        public int course { get; set; }
        public int flow { get; set; }
        public int group { get; set; }

        public Student(string firstName, string secondName, string lastName, string fNumber, string faculty, string specialty, DegreeType degreeType, StatusType statusType, DateTime lastCertification, int course, int flow, int group)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.lastName = lastName;
            this.fNumber = fNumber;
            this.faculty = faculty;
            this.specialty = specialty;
            this.degreeType = degreeType;
            this.statusType = statusType;
            this.lastCertification = lastCertification;
            this.course = course;
            this.flow = flow;
            this.group = group;
        }

    }
}
