using OOPProject.Db.Objects;
using OOPProject.Models.Interfaces;
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
    /// Logika interakcji dla klasy ActivitieEditWindow.xaml
    /// </summary>
    public partial class ActivitieEditWindow : Window
    {
        private IActivitieModel model;
        private Activitie activitie;

        public ActivitieEditWindow(Activitie activitie, IActivitieModel model)
        {
            InitializeComponent();
            this.model = model;
            this.activitie = activitie;
            InitializeFields();
        }

        private void InitializeFields()
        {
            NameTextBox.Text = activitie.Name;
            StartDateTime.Value = activitie.StartDate;
            EndDateTime.Value = activitie.EndDate;
            ParticipantsNumberUpDown.Value = activitie.ParticipantsNumber;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
