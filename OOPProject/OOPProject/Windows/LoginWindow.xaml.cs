using OOPProject.Db;
using OOPProject.Models;
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
                switch (response.Data[0].Type)
                {
                    case UserType.Admin:
                        new AdminWindow().Show();
                        break;
                    case UserType.Leader:
                        new LeaderWindow().Show();
                        break;
                    case UserType.Participant:
                        new ParticipantWindow().Show();
                        break;
                }
            Close();
        }
    }
}
