using OOPProject.Db.Objects;
using OOPProject.Models;
using System;
using System.Text;
using System.Windows;

namespace OOPProject
{
    /// <summary>
    /// Logika interakcji dla klasy LeaderWindow.xaml
    /// </summary>
    public partial class LeaderWindow : Window
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
            ActivitiesDataGrid.ItemsSource = leaderModel.GetActivities(user);
        }

        private void AddActivitieButton_Click(object sender, RoutedEventArgs e)
        {

            if (NewActivitieNameTextBox.Text == "")
            {
                MessageBox.Show("Musisz wpisać nazwę wydażenia");
                return;
            }

            if (NewActivitieStartDate.Value is null)
            {
                MessageBox.Show("Musisz wybrać datę rozpoczęcia");
                return;
            }

            if (NewActivitieEndDate.Value is null)
            {
                MessageBox.Show("Musisz wybrać datę zakończenia");
                return;
            }

            if (NewActivitieParticipantsNumber.Value is null)
            {
                MessageBox.Show("Musisz wybrać ilosć uczestników");
                return;
            }

            if (NewActivitieStartDate.Value > NewActivitieEndDate.Value)
            {
                MessageBox.Show("Data rozpoczęcia nie może być później niż data zakończenia");
                return;
            }

            if (NewActivitieParticipantsNumber.Value < 1)
            {
                MessageBox.Show("Liczba uczestników nie możę być taka mała");
                return;
            }

            var response = leaderModel.CreateActivitie(user, NewActivitieNameTextBox.Text, (DateTime)NewActivitieStartDate.Value, (DateTime)NewActivitieEndDate.Value, (int)NewActivitieParticipantsNumber.Value);

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
    }
}
