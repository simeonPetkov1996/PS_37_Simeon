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

namespace StudentInfoSystem
{
    
    public partial class MainPage : Page
    {
        private static User anonymousUser = new User(null, null, null, 0, new DateTime(), new DateTime());
        private User user = anonymousUser;

        public MainPage()
        {
            InitializeComponent();
            DisableTextBoxes();
            loginTB.IsEnabled = true;
            studentButton.Visibility = Visibility.Hidden;
            createStudentButton.Visibility = Visibility.Hidden;
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
            firtNameTB.Text = student.firstName;
            middleNameTB.Text = student.secondName;
            thirdNameTB.Text = student.lastName;
            facultyTB.Text = student.faculty;
            specialtyTB.Text = student.specialty;
            oksTB.Text = student.lastCertification.ToString();
            stateTB.Text = student.statusType.ToString();
            facNumberTB.Text = student.fNumber;
            courseTB.Text = student.course.ToString();
            flowTB.Text = student.flow.ToString();
            groupTB.Text = student.group.ToString();
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
            if (loginButton.Content.Equals("Провери"))
            {
                if (UserData.AllUsersUsernames().ContainsKey(loginTB.Text))
                {
                    user = UserData.TestUsers[UserData.AllUsersUsernames()[loginTB.Text]];
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
            if (user.role == 2)
            {
                facNumberTB.IsEnabled = true;
                studentButton.Visibility = Visibility.Visible;
                this.NavigationService.Navigate(new InspectorPage());
                

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

    }
}
