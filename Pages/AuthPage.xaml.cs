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
        static int s = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Auth(Login.Text, Password.Password);
        }
        public bool Auth(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите данные");
                return false;
            }
            using (var db = new Entities2())
            {
                var user = db.Employees.AsNoTracking().FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден");
                    return false;
                }
                MessageBox.Show("Пользователь успешно найден");
                Login.Clear();
                Password.Clear();




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
                return true;
            }
        }
        
    }
}
