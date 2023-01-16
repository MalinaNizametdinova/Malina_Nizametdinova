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
    /// Логика взаимодействия для AddSC.xaml
    /// </summary>
    public partial class AddSC : Page
    {
        private SC _currentSC = new SC();
        public AddSC()
        {
            InitializeComponent();
            DataContext = _currentSC;
        }

        private void ButtonCancel_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagerC());
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentSC.ID == 0)
                Entities2.GetContext().SC.Add(_currentSC);
            try
            {
                Entities2.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            NavigationService.Navigate(new ManagerC());

        }

        private void CmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
