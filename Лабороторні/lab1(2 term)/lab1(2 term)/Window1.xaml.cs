using System;
using System.IO;
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
using System.Windows.Shapes;

namespace lab1_2_term_
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string path = @"C:\Users\ilche\source\repos\lab1(2 term)\lab1(2 term)\Base.txt";

        public Window1()
        {
            InitializeComponent();
        }

        private void toMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Hide();
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            main.Show();
        }

        private void getRandStudentButton_Click(object sender, RoutedEventArgs e)
        {

            

            Random rnd = new Random();

            StreamReader Base = new StreamReader(path);

            int amountOfRecords = 0;

            while (!Base.EndOfStream)
            {
                Base.ReadLine();
                amountOfRecords++;
            }

            Base.DiscardBufferedData();
            Base.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

            int random = rnd.Next(1, amountOfRecords);

            for (int i = 1; i != random-1; i++)
                Base.ReadLine();

            string record = Base.ReadLine();

            string[] values = record.Split('\t');

            keyTextBox.Text = values[0];
            fullNameTextBox.Text = values[1];
            facultyTextBox.Text = values[2];
            specialityTextBox.Text = values[3];

            Base.Close();


        }

        private void deleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            string studentKey = keyTextBox.Text;
            var keys = File.ReadAllLines(path).ToList();
            keys.RemoveAt(keys.IndexOf(keys.Find(x => x.Contains(studentKey))));
            File.WriteAllLines(path, keys);
        }

        private void recordStudentButton_Click(object sender, RoutedEventArgs e)
        {
            string key = keyTextBox.Text;
            string fullName = fullNameTextBox.Text;
            string faculty = facultyTextBox.Text;
            string speciality = specialityTextBox.Text;

            

            File.AppendAllText(path, key + "/t" + fullName + "/t" + faculty + "/t" + speciality);
        }
    }
}
