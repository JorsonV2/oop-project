using OOPProject.Db.Objects;
using OOPProject.Models;
using OOPProject.Windows.Interfaces;
using System;
using System.Text;
using System.Windows;

namespace OOPProject
{
    /// <summary>
    /// Logika interakcji dla klasy LeaderWindow.xaml
    /// </summary>
    public partial class LeaderWindow : Window, IActivitieWindow
    {
        private LeaderModel leaderModel;
        private User user;
        public LeaderWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            leaderModel = new LeaderModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadActivitieDataGrid();
        }

        private void AddActivitieButton_Click(object sender, RoutedEventArgs e)
        {

            var name = NewActivitieNameTextBox.Text;
            var startDate = NewActivitieStartDate.Value;
            var endDate = NewActivitieStartDate.Value;
            var participantsNumber = NewActivitieParticipantsNumber.Value;

            if (name == "")
            {
                MessageBox.Show("Musisz wpisać nazwę wydażenia");
                return;
            }

            if (startDate is null)
            {
                MessageBox.Show("Musisz wybrać datę rozpoczęcia");
                return;
            }

            if (endDate is null)
            {
                MessageBox.Show("Musisz wybrać datę zakończenia");
                return;
            }

            if (participantsNumber is null)
            {
                MessageBox.Show("Musisz wybrać ilosć uczestników");
                return;
            }

            if (startDate > endDate)
            {
                MessageBox.Show("Data rozpoczęcia nie może być później niż data zakończenia");
                return;
            }

            if (participantsNumber < 1)
            {
                MessageBox.Show("Liczba uczestników nie możę być taka mała");
                return;
            }

            var response = leaderModel.CreateActivitie(user, name, (DateTime)startDate, (DateTime)endDate, (int)participantsNumber);

            if (response.Error)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(response.Message);
                foreach (var item in response.Data)
                {
                    sb.AppendLine($"{item.Name}: od {item.StartDate} do {item.EndDate}");
                }
                MessageBox.Show(sb.ToString());
            }
        }

        public void ReloadActivitieDataGrid()
        {
            ActivitiesDataGrid.ItemsSource = leaderModel.GetActivities(user);
        }
    }
}
