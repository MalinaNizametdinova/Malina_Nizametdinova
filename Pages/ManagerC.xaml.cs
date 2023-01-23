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
    /// Логика взаимодействия для ManagerC.xaml
    /// </summary>
    public partial class ManagerC : Page
    {
        private Entities2 _context = new Entities2();
        public ManagerC()
        {
            InitializeComponent();
            DataSC.ItemsSource = Entities2.GetContext().SC.ToList();
           
            Update();          
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e) // добавить
        {
            NavigationService.Navigate(new AddSC(null));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e) // удаление
        {
            var SCForRemoving = DataSC.SelectedItems.Cast<SC>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {SCForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    //  Entities2.GetContext().SC.RemoveRange(SCForRemoving);
                    Entities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataSC.ItemsSource = Entities2.GetContext().SC.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


        }

        private void ButtonEdit_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddSC((sender as Button).DataContext as SC));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // список павильонов
        {
            NavigationService.Navigate(new PavilionsPage());
        }
            
        private void Update()
        {
            var currentRe = Entities2.GetContext().SC.ToList();
            

            if (Goroda.Text != null)
            {
                currentRe = currentRe.Where(x => x.City.ToLower().Contains(Goroda.Text.ToLower())).ToList();
                DataSC.ItemsSource = currentRe.ToList();
            }

            if (txtStatus.Text != null)
            {
                currentRe = currentRe.Where(x => x.Status.ToLower().Contains(txtStatus.Text.ToLower())).ToList();
                DataSC.ItemsSource = currentRe.ToList();
            }

        }
        


        private void Goroda_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void Status_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
