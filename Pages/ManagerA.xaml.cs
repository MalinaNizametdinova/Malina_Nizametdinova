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
    /// Логика взаимодействия для ManagerA.xaml
    /// </summary>
    public partial class ManagerA : Page
    {
        public ManagerA()
        {
            InitializeComponent();
            DataTen.ItemsSource = Entities2.GetContext().Tenants.ToList();
            Update();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTen(null));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var TenForRemoving = DataTen.SelectedItems.Cast<Tenants>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {TenForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    //  Entities2.GetContext().Tenants.RemoveRange(TenForRemoving);
                    //Entities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataTen.ItemsSource = Entities2.GetContext().Tenants.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void ButtonEdit_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddTen((sender as Button).DataContext as Tenants));
        }

        private void Update()
        {
            var current = Entities2.GetContext().Tenants.ToList();
            if (Nazv.Text != null)
            {
                current = current.Where(x => x.Name.ToLower().Contains(Nazv.Text.ToLower())).ToList();
                DataTen.ItemsSource = current.ToList();
            }
        }

        private void Nazv_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

    }
}
