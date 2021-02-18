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
    /// Interaction logic for ParticipantActivitieDetails.xaml
    /// </summary>
    public partial class ParticipantActivitieDetails : Window
    {
        private Activitie activitie;
        private User user;

        public ParticipantActivitieDetails(Activitie activitie, User user)
        {
            InitializeComponent();
            this.activitie = activitie;
            this.user = user;
            InitializeFields();
        }

        private void InitializeFields()
        {
            using (var db = new ActivitiesContext())
            {
                var details = db.Activities.Find(activitie.ActivitieId);

                NameLabel.Content = details.Name;
                StartDateLabel.Content = details.StartDate.ToString();
                EndDateLabel.Content = details.EndDate.ToString();
                ParticipansNumbertLabel.Content = details.ParticipantsNumber.ToString();
                /*
                if (details.ActivitiesParticipants.OrderByDescending(ap => ap.SignUpDate).Take(details.ParticipantsNumber))
                {

                }
                */
            }
        }
    }
}
