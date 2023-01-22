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

namespace Malina_Nizametdinova.Pages
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        public Captcha()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            Random r = new Random();
            for (int i = 0; i < 5; i++)
                s += (char)(r.Next(1072, 1104));
            Word.Text = s;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Repeat.Text == Word.Text)
            {
                Close();
            }
            else Console.WriteLine("Попробуйте еще раз");
        }
    }
}
