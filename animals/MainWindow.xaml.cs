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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace animals
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[] x = new int[4];
            int n = 3;
            double [,] w = new double[n, x.Length];
            if (File.Exists("test.txt"))
            {
                string[] file_input = File.ReadAllLines(@"test.txt");
                weight_lb.Items.Clear();
                int j = 0; // Строка
                int r = 0; // столбец
                for (int i = 0; i < file_input.Length; i++)
                {
                    w[j, r] = Convert.ToDouble(file_input[i]);
                    weight_lb.Items.Add(file_input[i]);
                    if (r < x.Length - 1)
                    {
                        r++;
                    }
                    else
                    {
                        r = 0;
                        j++;
                    }
                }
                int errs = 0;
                string args_err ="";
                if (int.TryParse(legs.Text, out x[0]))
                {
                    if ((x[0] <6) & (x[0] >-6))
                        errs++;
                    else
                    {
                        args_err += "Количество ног, ";
                    }
                }
                else
                {
                    args_err += "Количество ног, ";
                }
                if (int.TryParse(water.Text, out x[1]))
                {
                    if ((x[1] < 6) & (x[1] > -6))
                        errs++;
                    else
                    {
                        args_err += "Живёт в воде, ";
                    }
                }
                else
                {
                    args_err += "Живёт в воде, ";
                }
                if (int.TryParse(fly.Text, out x[2]))
                {
                    if ((x[2] < 6) & (x[2] > -6))
                        errs++;
                    else
                    {
                        args_err += "Может летать, ";
                    }
                }
                else
                {
                    args_err += "Может летать, ";
                }
                if (int.TryParse(eggs.Text, out x[3]))
                {
                    if ((x[3] < 6) & (x[3] > -6))
                        errs++;
                    else
                    {
                        args_err += "Откладывает яйца, ";
                    }
                }
                else
                {
                    args_err += "Откладывает яйца, ";
                }
                if (errs != 4)
                {
                    MessageBox.Show("Неправильный ввод параметров: "+args_err+ "! Допускается -5, 5", "Ошибка ввода - вывода",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
                double[] y = Count_animals(x, w);
                answ.Content = get_answ(y);
                ys.Items.Clear();
                for (int i = 0; i< y.Length; i++)
                {
                    ys.Items.Add(y[i]);
                }
            }
            else
            {
                MessageBox.Show("Не найден фалй test.txt", "Ошибка ввода - вывода", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private double[] Count_animals(int[] x, double[,] w)
        {
            double[] agr = new double[3];
            for (int j = 0; j < x.Length -2; j++)
            {
                for (int i = 0; i < x.Length - 1; i++)
                    agr[i] = x[i] * w[j, i];
            }
            return agr;
        }

        private string get_answ(double[] y)
        {
            
            string outs ="";
            Boolean b = false;
            if ((y[0] <= 0) & (y[1] <= 4) & (y[2] <= 2))
            {
                outs += "Курица, ";
                b = true;
            }

            if ((y[0] >= 10) & (y[1] <= 4) & (y[2] <= -3))
            {
                outs += "Человек, ";
                b = true;
            }
            if ((y[0] >= 7) & (y[1] <= -2) & (y[2] >= 4))
            {
                outs += "Пигнвин, ";
                b = true;
            }
            if ((y[0] <= -9) & (y[1] <= -3) & (y[2] <= -7))
            {
                outs += "Осминог, ";
                b = true;
            }
                
            if ((y[0] >= 7) & (y[1] <= -3) & (y[2] <= 3))
            {
                b = true;
                outs += "Акула, ";
            }
                
            if ((y[0] >= 9) & (y[1] <= -4) & (y[2] <= -6))
            {
                outs += "Свинья, ";
                b = true;
            }
            if (b == false)
                outs = "Незнаю";
            return outs;
        }

        private void Dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
