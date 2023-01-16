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

namespace Malina_Nizametdinova.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(Password.Password))
            {
                MessageBox.Show("Введите логин или пароль!!");
                return;
            }
            using (var db = new Entities2())
            {
                var user = db.Employees
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == Login.Text && u.Password == Password.Password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return;
                }
                MessageBox.Show("Пользователь успешно найден!");
                switch (user.Role)
                {
                    case "Администратор":
                        NavigationService?.Navigate(new Admin());
                        break;
                    case "Менеджер А":
                        NavigationService?.Navigate(new ManagerA());
                        break;
                    case "Менеджер С":
                        NavigationService?.Navigate(new ManagerC());
                        break;
                }
            }
        }
    }
}
