using OOPProject.Db.Objects;
using OOPProject.Models;
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
    /// Logika interakcji dla klasy UserEditWindow.xaml
    /// </summary>
    public partial class UserEditWindow : Window
    {
        private UserModel model;
        private User user;

        public UserEditWindow(User user, UserModel model)
        {
            InitializeComponent();
            this.user = user;
            this.model = model;
            InitializeFields();
        }

        private void InitializeFields()
        {
            LoginLabel.Content = user.Login;
            PasswordTextBox.Password = user.Password;
            NameTextBox.Text = user.Name;
            TypeLabel.Content = user.Type;
        }
    }
}
