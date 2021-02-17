using OOPProject.Db.Objects;
using OOPProject.Models.Interfaces;
using OOPProject.Windows.Interfaces;
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
        private IActivitieWindow window;
        private IActivitieModel model;
        private Activitie activitie;

        public ActivitieEditWindow(Activitie activitie, IActivitieModel model, IActivitieWindow window)
        {
            InitializeComponent();
            this.model = model;
            this.activitie = activitie;
            this.window = window;
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
            var name = NameTextBox.Text;
            var startDate = StartDateTime.Value;
            var endDate = EndDateTime.Value;
            var participantsNumber = ParticipantsNumberUpDown.Value;

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

            var response = model.EditActivitie(activitie, name, (DateTime)startDate, (DateTime)endDate, (int)participantsNumber);

            MessageBox.Show(response.Message);

            if (!response.Error)
                window.ReloadActivitieDataGrid();
        }
    }
}
