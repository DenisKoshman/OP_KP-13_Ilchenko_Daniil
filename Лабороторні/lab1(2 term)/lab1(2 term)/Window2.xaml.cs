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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

            Grid grid = Game_Grid; //Define the grid

            for (int i = 0; i < 5; i++)
            {
                ColumnDefinition columna = new ColumnDefinition()
                {
                    Name = "Col_" + i,
                    Width = new GridLength(0.12, GridUnitType.Star),
                };
                grid.ColumnDefinitions.Add(columna);
            }

            for (int i = 0; i < 5; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(0.12, GridUnitType.Star);
                grid.RowDefinitions.Add(row);
            }

            

            Button[,] Game = new Button[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Game[i, j] = new Button()
                    {
                        Name = "button_" + i*5 + j,
                        Content = "",
                        Background = Brushes.White,
                    };

                    Game[i, j].Click += (sender, EventArgs) => { Game_Button_Click(sender, EventArgs, Game); };
                    Game[i,  j].Margin = new Thickness(2);

                    Grid.SetRow(Game[i,  j], i);
                    Grid.SetColumn(Game[i,  j], j);
                    grid.Children.Add(Game[i,  j]);
                }
            }
        }

        private void Game_Button_Click(object sender, RoutedEventArgs e, Button[,] Game)
        {
            Button cell = (Button) e.Source;

            if (cell.Background == (Brush)(new BrushConverter().ConvertFrom("#FF273655")) || cell.Background == (Brush)(new BrushConverter().ConvertFrom("#FFd8c9aa")))
                return;

            if (Blue_or_Red(Game)) 
            {
                cell.Background = Brushes.YellowGreen;
            }
            else
            {
                cell.Background = Brushes.Coral;
            }
                

            if (Check_Win(Game, cell))
            {
                MessageBox.Show("Win");
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Game[i, j].Background = Brushes.White;
                    }
                }
            }
        }

        private bool Blue_or_Red(Button[,] Game)
        {
            int count = 0;

            for(int i = 0; i < Game.GetLength(0); i++)
            {
                for(int j = 0; j < Game.GetLength(1); j++)
                {
                    if (Game[i,j].Background == Brushes.White)
                    {
                        count++;
                    }
                }
            }

            bool result = false;
            if (count % 2 == 1)
                result = true;


            return result;
        }

        private bool Check_Win(Button[,] Game, Button ClickedButton)
        {
            bool result = false;

            Brush color = ClickedButton.Background;

            List<Button[,]> buttons = new List<Button[,]>();

            for (int k = 0; k < 2;k++)
            {
                for(int m = 0; m < 2; m++)
                {
                    Button[,] part = new Button[4,4];
                    for(int i = 0; i < 4; i++)
                    {
                        for(int j = 0; j < 4; j++)
                        {
                            part[i, j] = Game[i + k, j + m];

                        }
                    }
                    buttons.Add(part);
                }
            }

            foreach(var massive in buttons)
            {
                if (ChekLines(massive, color) || checkDiagonal(massive, color))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
     

        private bool checkDiagonal(Button[,] map, Brush our_color)
        {
            bool toright, toleft;
            toright = true;
            toleft = true;
            for (int i = 0; i < 4; i++)
            {
                toright &= (map[i,i].Background == our_color);
                toleft &= (map[3 - i,i].Background == our_color);
            }

            if (toright || toleft) return true;

            return false;
        }

        private bool ChekLines(Button[,] map, Brush our_color)
        {
            bool rows = false, cols = false;

            for (int i = 0; i < 4; i++)
            {
                cols = true;
                rows = true;
                for (int j = 0; j < 4; j++)
                {
                    cols &= (map[i,j].Background == our_color);
                    rows &= (map[j,i].Background == our_color);
                }
                if (cols || rows) return true;
            }
            return false;
        }
            
        

        private void toMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Hide();
            main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            main.Show();
        }
    }
}
