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
    /// Interaction logic for InspectorPage.xaml
    /// </summary>
    public partial class InspectorPage : Page
    {
        public InspectorPage()
        {
            InitializeComponent();
            foreach (Student student in StudentData.DefaultStudents)
            {
                
                if (!Contains(student))
                {
                    ListBoxItem listBoxItem = new ListBoxItem();
                    listBoxItem.Content = student.group;
                    groupsLB.Items.Add(listBoxItem);
                }
            }
        }

        private bool Contains(Student student)
        {
            foreach(ListBoxItem listboxitem in groupsLB.Items)
            {
                if (listboxitem.Content.Equals(student.group))
                {
                    return true;
                }
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            studentsLB.Items.Clear();
            foreach(Student student in StudentData.DefaultStudents)
            {
                if (student.group.ToString().Equals((groupsLB.SelectedItem as ListBoxItem).Content.ToString()))
                {
                    ListBoxItem listBoxItem = new ListBoxItem();
                    listBoxItem.Content = student.firstName + " " + student.secondName + " " + student.lastName;
                    studentsLB.Items.Add(listBoxItem);
                }
            }
        }
    }
}
