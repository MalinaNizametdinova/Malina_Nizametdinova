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
    /// Логика взаимодействия для PavilionsPage.xaml
    /// </summary>
    public partial class PavilionsPage : Page
    {
        public PavilionsPage()
        {
            InitializeComponent();
            PavilionsList.ItemsSource = Entities2.GetContext().Pavilions.ToList();
            Update();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPavilion(null));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Entities2())
            {
                var paw = db.Pavilions
                    .AsNoTracking()
                    .FirstOrDefault();
                if (paw.Status == "Забронировано" || paw.Status == "Арендован")
                {
                    Console.WriteLine("Действие невозможно");
                }
                else
                {

                }
                var PavForRemoving = PavilionsList.SelectedItems.Cast<Pavilions>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {PavForRemoving.Count()} элементов?", "Внимание",
                                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    try
                    {
                        //Entities2.GetContext().Pavilions.RemoveRange(PavForRemoving);
                       // Entities2.GetContext().SaveChanges();
                        MessageBox.Show("Данные успешно удалены!");

                        PavilionsList.ItemsSource = Entities2.GetContext().Pavilions.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
            }

        }

        private void ButtonEdit_Click_1(object sender, RoutedEventArgs e)
        {
            //var Re = Entities2.GetContext().Pavilions.ToList();
            //Re = Re.Where(x => x.Status.ToList);
            //if(Re == "Арендован" || Re == "Забронирован")
            //{
            //    MessageBox.Show("Отмена");
            //    return;
            //}

            using (var db = new Entities2())
            {
                var paw = db.Pavilions
                    .AsNoTracking()
                    .FirstOrDefault();
                if (paw.Status == "Забронировано" || paw.Status == "Арендован")
                {
                    Console.WriteLine("Действие невозможно");
                }
                else
                {
                    NavigationService.Navigate(new Pages.AddPavilion((sender as Button).DataContext as Pavilions));
                }
            }
        }

        private void Update()
        {
            var currentRe = Entities2.GetContext().Pavilions.ToList();


            if (Stat.Text != null)
            {
                currentRe = currentRe.Where(x => x.Status.ToLower().Contains(Stat.Text.ToLower())).ToList();
                PavilionsList.ItemsSource = currentRe.ToList();
            }

            //if (Et.Text != null)
            //{
            //    currentRe = currentRe.Where(x => x.Floor.ToLower().Contains(Et.Text.ToLower())).ToList();
            //    PavilionsList.ItemsSource = currentRe.ToList();
            //}

        }

        private void Et_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void Stat_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
