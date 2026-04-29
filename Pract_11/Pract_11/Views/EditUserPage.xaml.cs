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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        private User _currentUser;

        public EditUserPage(User user)
        {
            InitializeComponent();
            _currentUser = user;

            CmbRole.ItemsSource = AppData.db1.Role.ToList();

            LoginTxb.Text = _currentUser.Login;
            Password_Txb.Text = _currentUser.Password;
            CmbRole.SelectedItem = AppData.db1.Role.FirstOrDefault(r => r.Id == _currentUser.RoleID);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _currentUser.Login = LoginTxb.Text;
            _currentUser.Password = Password_Txb.Text;

            var CurrentRole = CmbRole.SelectedItem as Role;

            if (CurrentRole != null)
            {
                _currentUser.RoleID = CurrentRole.Id;
            }

            AppData.db1.SaveChanges();
            MessageBox.Show("Пользователь был изменён");
            NavigationService.GoBack();
        }
    }
}
