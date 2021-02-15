using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOPProject
{
    public class Controller
    {
        private Model model;
        private Window currentWindow;

        public Controller()
        {
            model = new Model();
            currentWindow = new LoginWindow(this);
            currentWindow.Show();
        }

        public void Login(string login, string password)
        {
            var response = model.ConfirmUser(login, password);
            if (response.Error)
                ShowMessage(response.Message);
            else
            {
                currentWindow.Close();
                switch (response.Data.First().Type)
                {
                    case UserType.Admin:
                        currentWindow = new AdminWindow();
                        break;
                    case UserType.Leader:
                        currentWindow = new LeaderWindow();
                        break;
                    case UserType.Participant:
                        currentWindow = new ParticipantWindow();
                        break;
                }
                currentWindow.Show();
            }   
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
