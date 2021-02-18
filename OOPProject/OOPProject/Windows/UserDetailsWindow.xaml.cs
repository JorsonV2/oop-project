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
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private User user;
        private User participant;
        public UserDetailsWindow(User user, User participant)
        {
            InitializeComponent();
            this.user = user;
            this.participant = participant;
            InitializeFields();
        }

        private void InitializeFields()
        {
            nameLabel.Content = participant.Name;
            using (var db = new ActivitiesContext())
            {
                detailsLabel.AppendText(db.ParticipantsDescriptions.Where(pd => pd.LeaderLogin == user.Login && pd.ParticipantLogin == participant.Login).FirstOrDefault().Description);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ActivitiesContext())
            {
                var found = db.ParticipantsDescriptions.Where(pd => pd.LeaderLogin == user.Login && pd.ParticipantLogin == participant.Login).FirstOrDefault();
                found.Description = new TextRange(detailsLabel.Document.ContentStart, detailsLabel.Document.ContentEnd).Text;
                db.SaveChanges();
            }
        }
    }
}
