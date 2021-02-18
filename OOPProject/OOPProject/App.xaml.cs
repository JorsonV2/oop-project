using OOPProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OOPProject
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            new StartModel();
            new LoginWindow().Show();
        }

        public void Logout()
        {
            new LoginWindow().Show();
            for (int i = 0; i < Current.Windows.Count; i++)
                if (!Current.Windows[i].GetType().IsInstanceOfType((typeof(LoginWindow))))
                    Current.Windows[i].Close();      
        }
    }
}
