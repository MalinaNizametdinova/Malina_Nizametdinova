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
    /// Логика взаимодействия для AddPavilion.xaml
    /// </summary>
    public partial class AddPavilion : Page
    {
        private Pavilions _currentPavilion = new Pavilions();
        public AddPavilion(Pavilions selectedPavilion)
        {
            InitializeComponent();
            if (selectedPavilion != null)
            {
                _currentPavilion = selectedPavilion;
            }
            DataContext = _currentPavilion;
        }

        private void ButtonCancel_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PavilionsPage());
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Entities2.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void CmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
