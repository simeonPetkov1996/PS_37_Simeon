using StudentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for GradesPAge.xaml
    /// </summary>
    public partial class GradesPAge : Page
    {
        public GradesPAge()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int gradeValue;
            if(String.IsNullOrEmpty(Subject.Text)|| String.IsNullOrEmpty(FNumber.Text)|| String.IsNullOrEmpty(Grade.Text) || !Int32.TryParse(Grade.Text, out gradeValue))
            {
                MessageBox.Show("Invalid values");
                return;
            }

            else
            {
                StudentInfoContext context = new StudentInfoContext();
                IEnumerable<Student> Students = context.Students;
                Student student = null;
                foreach(Student st in Students)
                {
                    if (st.fNumber.Equals(FNumber.Text))
                    {
                        student = st;
                        break;
                    }
                }
                if(student == null)
                {
                    MessageBox.Show("Invalid fNumber");
                    return;
                }
                if (gradeValue < 2 || gradeValue > 6)
                {
                    MessageBox.Show("Invalid fNumber");
                    return;
                }
                if (student.grades == null)
                {
                    student.grades = new List<Grade>();
                }
                student.grades.Add(new StudentRepository.Grade(gradeValue, Subject.Text));

                context.SaveChanges();
                FNumber.Text = "";
                Subject.Text = "";
                Grade.Text = "";
            }
        }


    }
}
