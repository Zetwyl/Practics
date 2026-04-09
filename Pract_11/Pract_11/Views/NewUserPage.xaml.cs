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
    /// Логика взаимодействия для NewUserPage.xaml
    /// </summary>
    public partial class NewUserPage : Page
    {
        public NewUserPage()
        {
            InitializeComponent();
            CmbRole.ItemsSource = AppData.db1.Role.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            User people = new User();

            people.Login = LoginTxb.Text;
            people.Password = Password_Txb.Text;

            var CurrentRole = CmbRole.SelectedItem as Role;
            people.RoleID = CurrentRole.Id;

            AppData.db1.User.Add(people);
            AppData.db1.SaveChanges();
            MessageBox.Show("Пользователь был добавлен в базу");
            NavigationService.GoBack();
        }
    }
}
