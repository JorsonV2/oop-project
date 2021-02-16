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

namespace OOPProject
{
    /// <summary>
    /// Logika interakcji dla klasy LeaderWindow.xaml
    /// </summary>
    public partial class LeaderWindow : Window
    {
        private User user;
        public LeaderWindow(User user)
        {
            InitializeComponent();
            this.user = user;

            ActivitiesDataGrid.ItemsSource = new ActivitiesContext().Users.Find(user.Login).Activities;
        }
    }
}
