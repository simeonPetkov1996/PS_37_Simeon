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
using UserLogin;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data.Entity;

namespace StudentInfoSystem
{
    
    public partial class MainPage : Page
    {

        private static User anonymousUser = new User(null, null, null, 0, new DateTime(), new DateTime());
        private User user = anonymousUser;

        public List<Student> Students
        {
            get
            {
                return StudentData.DefaultStudents;
            }
        }

        public List<string> StudStatusChoices { get; set; }


        public MainPage()
        {
            
            InitializeComponent();

            Database.SetInitializer<StudentInfoContext>(new DropCreateDatabaseIfModelChanges<StudentInfoContext>());

            DisableTextBoxes();
            loginTB.IsEnabled = true;
            studentButton.Visibility = Visibility.Hidden;
            createStudentButton.Visibility = Visibility.Hidden;
            //FillStudStatusChoices();
            this.DataContext = this;
            StudentInfoContext context = new StudentInfoContext();
            IsGradesTableEmtpy(context);
            IsLogsTableEmtpy(context);
            if (IsStudentsTableEmtpy(context))
            {
                SaveStudentsInTable(context);
            }
            if (IsUserTableEmtpy(context))
            {
                SaveUsersInTable(context);
            }
        }

        private Boolean IsStudentsTableEmtpy(StudentInfoContext context)
        {
            IEnumerable<Student> queryStudents = context.Students;
            if (queryStudents.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean IsGradesTableEmtpy(StudentInfoContext context)
        {
            IEnumerable<Grade> quertGrades = context.Grades;
            if (quertGrades.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean IsLogsTableEmtpy(StudentInfoContext context)
        {
            IEnumerable<Logs> queryLogs = context.Logs;
            if (queryLogs.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveStudentsInTable(StudentInfoContext context)
        {
            foreach (Student st in StudentData.DefaultStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
        }

        private Boolean IsUserTableEmtpy(StudentInfoContext context)
        {
            IEnumerable<User> queryUsers = context.Users;
            if (queryUsers.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveUsersInTable(StudentInfoContext context)
        {
            foreach (User user in UserData.TestUsers)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }

        private void ClearTextBoxes()
        {
            foreach (var item in mainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }

        private void SetStudentData(Student student)
        {
            this.DataContext = student;
            ListBoxItem item = new ListBoxItem();
            item.Content = student.faculty;

            facultyLB.SelectedItem = facultyLB.Items[0];
            facultyLB.ScrollIntoView(facultyLB.Items[0]);
        }

        private void DisableTextBoxes()
        {
            foreach (var item in mainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
        }

        private void testButton1_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }

        private void testButton2_Click(object sender, RoutedEventArgs e)
        {
            SetStudentData(StudentData.DefaultStudents[0]);
        }

        private void testButton3_Click(object sender, RoutedEventArgs e)
        {
            DisableTextBoxes();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<User> Users = context.Users;
            if (loginButton.Content.Equals("Провери"))
            {
                if (UserData.AllUsersUsernames().ContainsKey(loginTB.Text))
                {
                    user = Users.ElementAt(UserData.AllUsersUsernames()[loginTB.Text]);
                    infoLabel.Content = "Потребител " + user.username;
                    loginLable.Content = "Парола:";
                    loginTB.Clear();
                    loginButton.Content = "Влез";
                }
                else
                {
                    infoLabel.Content = "Невалиден потребител";
                    loginTB.Text = "";
                }
            }
            else if (loginButton.Content.Equals("Влез"))
            {
                if (user.password.Equals(loginTB.Text))
                {
                    infoLabel.Content = "Влязъл Потребител " + user.username;
                    loginLable.Content = "";
                    loginTB.Clear();
                    loginTB.IsEnabled = false;
                    loginButton.Content = "Излез";
                    loadFunctionalitiesAccordingRole();
                    //context.Logger.Add(new Logs("User " + user.username + " logged"));
                    //context.SaveChanges();
                }
                else
                {
                    user = anonymousUser;
                    infoLabel.Content = "Невалидна парола";
                    loginLable.Content = "Потр. име:";
                    loginTB.Clear();
                    loginButton.Content = "Провери";
                }
            }
            else if (loginButton.Content.Equals("Излез"))
            {
                user = anonymousUser;
                infoLabel.Content = "";
                loginLable.Content = "Потр. име:";
                loginButton.Content = "Провери";
                DisableTextBoxes();
                ClearTextBoxes();
                loginTB.IsEnabled = true;
                studentButton.Visibility = Visibility.Hidden;
                createStudentButton.Visibility = Visibility.Hidden;
                
            }
        }

        private void loadFunctionalitiesAccordingRole()
        {
            if (user.role == 3)
            {
                facNumberTB.IsEnabled = true;
                studentButton.Visibility = Visibility.Visible;
                this.NavigationService.Navigate(new InspectorPage());
                

            }
            if (user.role == 2)
            {
                facNumberTB.IsEnabled = true;
                studentButton.Visibility = Visibility.Visible;
                this.NavigationService.Navigate(new GradesPAge());


            }
            else if (user.role == 4)
            {
                SetStudentData(StudentData.GetStudent(user.number));
            }
        }

        private void studentButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentData.GetStudent(facNumberTB.Text) != null)
            {
                SetStudentData(StudentData.GetStudent(facNumberTB.Text));
            }
            else
            {
                ClearTextBoxes();
                createStudentButton.Visibility = Visibility.Visible;
            }
        }



        private void createStudentButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                    @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

    }
}
