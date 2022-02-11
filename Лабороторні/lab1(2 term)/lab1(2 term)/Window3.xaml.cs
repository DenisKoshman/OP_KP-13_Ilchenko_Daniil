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
using System.Windows.Shapes;

namespace lab1_2_term_
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void NumberInput(object sender, RoutedEventArgs e)
        {
            Button s = (Button)sender;
            textBox.Text += s.Content;
        }

        private void toMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Hide();
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            main.Show();
        }

        private void Button_erase_Click(object sender, RoutedEventArgs e)
        {
            try { textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1); } catch { };

        }

        delegate double MathOperation(double a, double b);

        static MathOperation oper = new MathOperation(NoAction);
        static double number1 = 0, number2 = 0;

        static private double NoAction(double a, double b) => 0;
        static private double divide_Action(double a, double b) => a / b;
        static private double multi_Action(double a, double b) => a * b;
        static private double plus_Action(double a, double b) => a + b;
        static private double minus_Action(double a, double b) => a - b;

        private void Button_divide_Click(object sender, RoutedEventArgs e)
        {
            number1 = double.Parse(textBox.Text);
            textBox.Text = textBox.Text.Remove(0);

            oper = new MathOperation(divide_Action);
        }

        private void Button_multi_Click(object sender, RoutedEventArgs e)
        {
            number1 = double.Parse(textBox.Text);
            textBox.Text = textBox.Text.Remove(0);

            oper = new MathOperation(multi_Action);
        }

        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {
            number1 = double.Parse(textBox.Text);
            textBox.Text = textBox.Text.Remove(0);

            oper = new MathOperation(minus_Action);
        }

        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {
            number1 = double.Parse(textBox.Text);
            textBox.Text = textBox.Text.Remove(0);

            oper = new MathOperation(plus_Action);
        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            oper = NoAction;
        }

        private void Button_delete_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text.Remove(0);
        }

        private void Button_Result_Click(object sender, RoutedEventArgs e)
        {
            number2 = double.Parse(textBox.Text);
            textBox.Text = oper(number1,number2).ToString();
        }
    }
}
