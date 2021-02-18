using OOPProject.Db.Objects;
using OOPProject.Models;
using OOPProject.Windows;
using System.Windows;
using System.Windows.Controls;

namespace OOPProject
{
    /// <summary>
    /// Logika interakcji dla klasy ParticipantWindow.xaml
    /// </summary>
    public partial class ParticipantWindow : Window
    {
        private ParticipantModel participantModel;
        private User user;

        public ParticipantWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            participantModel = new ParticipantModel(user);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadActivities();
        }

        public void ReloadActivities()
        {
            ReloadNotSignedInDataGrid();
            RealoadSignedInDataGrid();
            //ReloadSignedInAndQueueDataGrid();
        }

        public void ReloadNotSignedInDataGrid()
        {
            NotSignedInActivitiesDataGrid.ItemsSource = participantModel.GetNotSignedInActivities(user);
        }

        public void RealoadSignedInDataGrid()
        {
            SignedInActivitiesDataGrid.ItemsSource = participantModel.GetSignerInActivities(user);
        }

        public void ReloadSignedInAndQueueDataGrid()
        {
            var list = participantModel.GetSignedInAndInQueueActivities(user);
            SignedInActivitiesDataGrid.ItemsSource = list[0];
            SignedInQueueActivitiesDataGrid.ItemsSource = list[1];
        }

        private void NotSignedInActivitiesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((DataGrid)sender).SelectedItem is null)
                SignInButton.IsEnabled = false;
            else
                SignInButton.IsEnabled = true;
        }

        private void SignedInQueueActivitiesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((DataGrid)sender).SelectedItem is null)
                SignOutFromQueueButton.IsEnabled = false;
            else
                SignOutFromQueueButton.IsEnabled = true;
        }

        private void SignedInActivitiesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((DataGrid)sender).SelectedItem is null)
            {
                SignOutFromSingedInButton.IsEnabled = false;
                
            }
            else
            {
                SignOutFromSingedInButton.IsEnabled = true;
                DetailsButton.IsEnabled = true;
            }
                
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            var response = participantModel.SignIn((Activitie)NotSignedInActivitiesDataGrid.SelectedItem, user);
            MessageBox.Show(response.Message);
            ReloadActivities();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Logout();
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            new ParticipantActivitieDetails((Activitie)SignedInActivitiesDataGrid.SelectedItem, user).Show();
        }

        private void SignOutFromSingedInButton_Click(object sender, RoutedEventArgs e)
        {
            participantModel.SignOut((Activitie)SignedInActivitiesDataGrid.SelectedItem, user);
            ReloadActivities();
        }
    }
}
