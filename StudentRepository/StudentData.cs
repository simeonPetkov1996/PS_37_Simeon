using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public static class StudentData
    {

        public static List<Student> DefaultStudents
        {
            get
            {
                ResetTestStudentData();
                return _defaultStudents;
            }

            set
            {
            }
        }

        private static List<Student> _defaultStudents;


        private static void ResetTestStudentData()
        {
            _defaultStudents = new List<Student>();
            _defaultStudents.Add(new Student("Simeon", "Plamenov", "Petkov", "121215078", "FKST", "KSI", DegreeType.BACHELOR, StatusType.CERTIFIED, Convert.ToDateTime("01.02.2018 г. 14:12:24"), 3, 9, 37));
            _defaultStudents.Add(new Student("Dimo", "Hristov", "Georgiev", "121215074", "FKST", "KSI", DegreeType.BACHELOR, StatusType.CERTIFIED, Convert.ToDateTime("01.02.2018 г. 14:12:24"), 3, 9, 37));
            _defaultStudents.Add(new Student("Pesho", "Petrov", "Petrov", "121215079", "FKST", "KSI", DegreeType.BACHELOR, StatusType.CERTIFIED, Convert.ToDateTime("01.02.2018 г. 14:12:24"), 3, 9, 38));
            _defaultStudents.Add(new Student("Sasho", "Aleksandrov", "Aleksandrov", "121215080", "FKST", "KSI", DegreeType.BACHELOR, StatusType.CERTIFIED, Convert.ToDateTime("01.02.2018 г. 14:12:24"), 3, 9, 39));
        }

        public static String PrepareCertificate(String fNumber)
        {
            Student student = GetStudent(fNumber);
            return String.Format("Student {0} {1} {2} with faculty number {3} has status {4} for {5} degree.", student.firstName, student.secondName, student.lastName, student.fNumber, student.statusType.ToString(), student.degreeType.ToString());
        }

        public static Student GetStudent(String fNumber)
        {
            List<Student> studentAsList = (from student in DefaultStudents
                                           where student.fNumber.Equals(fNumber)
                                           select student).ToList();
            return studentAsList.Count == 0 ? null : studentAsList.First();
        }

        public static void SaveCertificate(String certificate, String file)
        {
            if (File.Exists(file))
            {
                throw new ArgumentException(String.Format("File {0} already exists.", file));
            }
            File.WriteAllText(file, certificate);
        }
    }
}
