using OOPProject.Db;
using OOPProject.Db.Objects;
using OOPProject.Models;
using OOPProject.Windows;
using OOPProject.Windows.Interfaces;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OOPProject
{
    /// <summary>
    /// Logika interakcji dla klasy AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window, IUserWindow
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
            ReloadUsersDataGrid();
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

        private void ChangeUsersButtonsEnable()
        {
            DeleteUserButton.IsEnabled = !DeleteUserButton.IsEnabled;
            EditUserButton.IsEnabled = !EditUserButton.IsEnabled;
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = (User)UsersDataGrid.SelectedItem;

            var result = MessageBox.Show($"Czy napewno chcesz usunąc użytkownika {selectedUser.Login}?", "Are you siure?", MessageBoxButton.YesNo);
            
            if(result == MessageBoxResult.Yes)
            {
                var response = adminModel.DeleteUser(selectedUser.Login);
                MessageBox.Show(response.Message);
                UsersDataGrid.ItemsSource = adminModel.GetUsers();
            }
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            new UserEditWindow((User)UsersDataGrid.SelectedItem, adminModel, this).Show();
        }

        public void ReloadUsersDataGrid()
        {
            UsersDataGrid.ItemsSource = adminModel.GetUsers();
        }
    }
}
