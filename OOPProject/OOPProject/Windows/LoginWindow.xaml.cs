using OOPProject.Db;
using OOPProject.Db.Objects;
using OOPProject.Models;
using OOPProject.Windows;
using System.Windows;

namespace OOPProject
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginModel loginModel;

        public LoginWindow()
        {
            InitializeComponent();
            loginModel = new LoginModel();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var response = loginModel.ConfirmUser(LoginText.Text, PasswordText.Password);
            if (response.Error)
                MessageBox.Show(response.Message);
            else
            {
                switch (response.Data[0].Type)
                {
                    case UserType.Admin:
                        new AdminWindow(response.Data[0]).Show();
                        break;
                    case UserType.Leader:
                        new LeaderWindow(response.Data[0]).Show();
                        break;
                    case UserType.Participant:
                        new ParticipantWindow(response.Data[0]).Show();
                        break;
                }
                Close();
            }    
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            new RegisterWindow().Show();
            Close();
        }
    }
}
