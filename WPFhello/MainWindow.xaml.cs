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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            String s = "";
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    s = s + ((TextBox)item).Text;
                    s = s + '\n';
                }
            }

            if (txtName.Text.Length > 2)
            {
                MessageBox.Show("Здрасти " + txtName.Text + "!!! \nТова е твоята първа програма на Visual Studio 2012!" + "\n" + s);
            }
            else
            {
                MessageBox.Show("Невалидно име!");
            }
        }

        private void OnClosing(object sender, System.EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Затвори прозореца?", "Сигурен ли си?", MessageBoxButton.YesNo);
            ((CancelEventArgs)e).Cancel = MessageBoxResult.No == result;
            
        }

        private void tbButton_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = DateTime.Now.ToString();
        }
    }
}
