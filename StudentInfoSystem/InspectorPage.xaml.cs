using StudentRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public List<Student> Students { get; set; }

        public InspectorPage()
        {
            
            InitializeComponent();
            Students = StudentData.DefaultStudents;
            dg.ItemsSource = Students;
            dg.Items.Refresh();
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
            Students.Clear();
            foreach(Student student in StudentData.DefaultStudents)
            {
                if (student.group.ToString().Equals((groupsLB.SelectedItem as ListBoxItem).Content.ToString()))
                {
                    Students.Add(student);
                }
            }
            dg.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Students = StudentData.DefaultStudents;
            dg.ItemsSource = Students;
            dg.Items.Refresh();
        }
    }
}
