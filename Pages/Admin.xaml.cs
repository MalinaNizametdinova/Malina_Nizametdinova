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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            DataEmp.ItemsSource = Entities2.GetContext().Employees.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmp(null));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var EmpForRemoving = DataEmp.SelectedItems.Cast<Employees>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {EmpForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    //  Entities2.GetContext().SC.RemoveRange(SCForRemoving);
                    Entities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataEmp.ItemsSource = Entities2.GetContext().SC.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void ButtonEdit_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddEmp((sender as Button).DataContext as Employees));
        }

        
        
    }
}
