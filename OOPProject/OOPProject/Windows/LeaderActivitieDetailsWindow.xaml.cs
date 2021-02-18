using OOPProject.Db;
using OOPProject.Db.Objects;
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
    /// Interaction logic for LeaderActivitieDetailsWindow.xaml
    /// </summary>
    public partial class LeaderActivitieDetailsWindow : Window
    {
        private Activitie activitie;
        private User user;
        public LeaderActivitieDetailsWindow(Activitie activitie, User user)
        {
            InitializeComponent();
            this.activitie = activitie;
            this.user = user;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new ActivitiesContext())
            {
                userDataGrid.ItemsSource = db.ActivitiesParticipants.Where(ap => ap.ActivitieId == activitie.ActivitieId).ToList();
            }
        }

        private void UserDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            new UserDetailsWindow(user, (User)userDataGrid.SelectedItem).Show();
        }

        private void userDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((DataGrid)sender).SelectedItem is null)
                UserDetailsButton.IsEnabled = false;
            else
                UserDetailsButton.IsEnabled = true;
        }
    }
}
