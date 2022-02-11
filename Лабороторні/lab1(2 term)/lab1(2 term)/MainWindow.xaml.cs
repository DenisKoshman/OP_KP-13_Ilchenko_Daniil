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

namespace lab1_2_term_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        private void toWin1_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            Hide();
            w1.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w1.Show();
        }
        private void toWin2_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            Hide();
            w2.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w2.Show();
        }

        private void toWin3_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            Hide();
            w3.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w3.Show();
        }

        private void toWin4_Click(object sender, RoutedEventArgs e)
        {
            Window4 w4 = new Window4();
            Hide();
            w4.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w4.Show();
        }
    }
}
