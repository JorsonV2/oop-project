using OOPProject.Db;
using OOPProject.Db.Objects;
using OOPProject.Models;
using OOPProject.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace OOPProject
{
    /// <summary>
    /// Logika interakcji dla klasy AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private AdminModel adminModel;
        private User user;

        public AdminWindow(User user)
        {
            InitializeComponent();
            adminModel = new AdminModel();
            this.user = user;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UsersDataGrid.ItemsSource = adminModel.GetUsers();
            ActivitiesDataGrid.ItemsSource = adminModel.GetActivities();
            ActivitiesParticipantsDataGrid.ItemsSource = adminModel.GetActivitiesParticipants();
            NewUserType.ItemsSource = Enum.GetValues(typeof(UserType)).Cast<UserType>();
        }

        private void AddNewUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewUserLogin.Text == "")
            {
                MessageBox.Show("Musisz podać login użytkownika");
                return;
            }

            if (NewUserPassword.Text == "")
            {
                MessageBox.Show("Musisz podać hasło użytkownika");
                return;
            }

            if (NewUserName.Text == "")
            {
                MessageBox.Show("Musisz podać nazwę użytkownika");
                return;
            }

            if (NewUserType.SelectedItem == null)
            {
                MessageBox.Show("Musisz podać typ użytkownika");
                return;
            }

            var response = adminModel.CreateUser(NewUserLogin.Text, NewUserPassword.Text, NewUserName.Text, (UserType) NewUserType.SelectedItem);

            MessageBox.Show(response.Message);
        }

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem == null)
                ChangeUsersButtonsEnable();
            else if (!DeleteUserButton.IsEnabled)
                ChangeUsersButtonsEnable();

        }

    }
}
