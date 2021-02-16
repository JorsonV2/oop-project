using OOPProject.Models;
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
using System.Windows.Shapes;

namespace OOPProject.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private RegisterModel registerModel;
        public RegisterWindow()
        {
            InitializeComponent();
            registerModel = new RegisterModel();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginText.Text == "")
            {
                MessageBox.Show("Musisz poać login");
                return;
            }

            if (PasswordText.Password == "")
            {
                MessageBox.Show("Musisz podać hasło");
                return;
            }

            if (NameText.Text == "")
            {
                MessageBox.Show("Musisz podać nazwę");
                return;
            }

            var response = registerModel.RegisterParticipant(LoginText.Text, PasswordText.Password, NameText.Text);
            MessageBox.Show(response.Message);     
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
    }
}
