using Pract_11.ADO;
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

namespace Pract_11.Views
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        public DataPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewUserPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить пользователя", "Уведомление", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentUser = UsersGrid.SelectedItem as User;
                AppData.db1.User.Remove(CurrentUser);
                AppData.db1.SaveChanges();

                UsersGrid.ItemsSource = AppData.db1.User.ToList();
                MessageBox.Show("success");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var CurrentUser = UsersGrid.SelectedItem as User;
            if (CurrentUser == null)
            {
                MessageBox.Show("Выберите пользователя для изменения");
                return;
            }
            NavigationService.Navigate(new EditUserPage(CurrentUser));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = AppData.db1.User.ToList();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var DelUs = AppData.db1.User.Where(c => c.Login.Contains(poisk.Text)).ToList();
            if (DelUs.Count == 0)
            {
                MessageBox.Show("Пользователя с таким логином нет в базе");
                UsersGrid.ItemsSource = AppData.db1.User.ToList();
            }
            else
            {
                UsersGrid.ItemsSource = DelUs;
            }
        }

        private void filter_btn_Click(object sender, RoutedEventArgs e)
        {
            var DelUs = AppData.db1.User.Where(c => c.Password == filter.Text).ToList();
            if (DelUs.Count == 0)
            {
                MessageBox.Show("Пользователя с таким паролем нет в базе");
                UsersGrid.ItemsSource = AppData.db1.User.ToList();
            }
            else
            {
                UsersGrid.ItemsSource = DelUs;
            }
        }

        private void sortirovka_btn_Click(object sender, RoutedEventArgs e)
        {
            var DelUs = AppData.db1.User.OrderByDescending(c => c.Login).ToList();
            if (DelUs.Count == 0)
            {
                MessageBox.Show("Пользователя ///");
                UsersGrid.ItemsSource = AppData.db1.User.ToList();
            }
            else
            {
                UsersGrid.ItemsSource = DelUs;
            }
        }
    }
}
