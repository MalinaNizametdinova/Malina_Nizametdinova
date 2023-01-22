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
    /// Логика взаимодействия для AddTen.xaml
    /// </summary>
    public partial class AddTen : Page
    {
        private Tenants _currentTen = new Tenants();
        public AddTen(Tenants selectedTen)
        {
            InitializeComponent();
            if (selectedTen != null)
            {
                _currentTen = selectedTen;
            }
            DataContext = _currentTen;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTen.ID == 0)
                Entities2.GetContext().Tenants.Add(_currentTen);
            try
            {
                Entities2.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            NavigationService.Navigate(new ManagerA());
        }

        private void ButtonCancel_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerA());
        }
    }
}
