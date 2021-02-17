using OOPProject.Db.Objects;
using OOPProject.Models;
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
            ActivitiesDataGrid.ItemsSource = leaderModel.GetActivities();
        }
    }
}
