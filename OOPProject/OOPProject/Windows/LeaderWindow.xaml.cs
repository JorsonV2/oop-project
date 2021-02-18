using OOPProject.Db.Objects;
using OOPProject.Models;
using OOPProject.Windows;
using OOPProject.Windows.Interfaces;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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
            else
                MessageBox.Show(response.Message);

            ReloadActivitieDataGrid();
        }

        public void ReloadActivitieDataGrid()
        {
            ActivitiesDataGrid.ItemsSource = leaderModel.GetActivities(user);
        }

        private void DeleteActivitieButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedActivitie = (Activitie)ActivitiesDataGrid.SelectedItem;

            var result = MessageBox.Show($"Czy napewno chcesz usunąc zajęcia {selectedActivitie.Name}?", "Are you siure?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                var response = leaderModel.DeleteActivitie(selectedActivitie);
                MessageBox.Show(response.Message);
                ReloadActivitieDataGrid();
            }
        }

        private void EditActivitieButton_Click(object sender, RoutedEventArgs e)
        {
            new ActivitieEditWindow((Activitie)ActivitiesDataGrid.SelectedItem, leaderModel, this).Show();
        }

        private void ActivitiesDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            if (dg.SelectedItem == null)
                ChangeActivitieButtonsEnable();
            else if (!DeleteActivitieButton.IsEnabled)
                ChangeActivitieButtonsEnable();
        }

        private void ChangeActivitieButtonsEnable()
        {
            DeleteActivitieButton.IsEnabled = !DeleteActivitieButton.IsEnabled;
            EditActivitieButton.IsEnabled = !EditActivitieButton.IsEnabled;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Logout();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new LeaderActivitieDetailsWindow((Activitie)ActivitiesDataGrid.SelectedItem, user).Show();
        }
    }
}
