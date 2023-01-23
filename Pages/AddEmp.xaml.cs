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
    /// Логика взаимодействия для AddEmp.xaml
    /// </summary>
    public partial class AddEmp : Page
    {
        private Employees _currentEmp = new Employees();
        public AddEmp(Employees selectedEmp)
        {
            InitializeComponent();
            if (selectedEmp != null)
            {
                _currentEmp = selectedEmp;
            }
            DataContext = _currentEmp;
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            txthintNumber.Visibility = Visibility.Visible;
            if (Number.Text.Length > 0)
            {
                txthintNumber.Visibility = Visibility.Hidden;
            }
        }

        private void CmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonCancel_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Admin());
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentEmp.Login))
                errors.AppendLine("Укажите логин!");
            if (string.IsNullOrWhiteSpace(_currentEmp.Password))
                errors.AppendLine("Укажите пароль!");
            if ((_currentEmp.Role == null) || (CmbRole.Text == ""))
                errors.AppendLine("Выберите роль!");
            else
                _currentEmp.Role = CmbRole.Text;
            if (string.IsNullOrWhiteSpace(_currentEmp.FIO))
                errors.AppendLine("Укажите Ф.И.О.!");
            if (string.IsNullOrWhiteSpace(_currentEmp.Gender))
                errors.AppendLine("Укажите пол!");
            if (string.IsNullOrWhiteSpace(_currentEmp.Image))
                errors.AppendLine("Укажите фото!");
            if (string.IsNullOrWhiteSpace(_currentEmp.Number))
                errors.AppendLine("Укажите номер!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentEmp.ID == 0)
                Entities2.GetContext().Employees.Add(_currentEmp);
            try
            {
                Entities2.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            NavigationService.Navigate(new Admin());
        }

        private void Number_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
