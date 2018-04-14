using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentRepository
{
    public class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            if(user.number == null || StudentData.GetStudent(user.number) == null)
            {
                throw new Exception();
            } else
            {
                return StudentData.GetStudent(user.number);
            }
        }
    }
}
