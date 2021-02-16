using OOPProject.Db;
using OOPProject.Windows;
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
    /// Logika interakcji dla klasy AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private User user;
        private ListCollectionView groupedUsers;

        public AdminWindow(User user)
        {
            InitializeComponent();
            this.user = user;

            UsersDataGrid.ItemsSource = new ActivitiesContext().Users.ToList();

        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
