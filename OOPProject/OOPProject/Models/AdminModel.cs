using OOPProject.Db;
using OOPProject.Db.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Models
{
    public class AdminModel
    {
        private ActivitiesContext db;

        public AdminModel()
        {
            db = new ActivitiesContext();
        }

        public Response<User> CreateUser(string login, string password, string name, UserType userType)
        {

            var users = db.Users.Where(u => u.Login == login);
            if (users.Count() > 0)
                return new Response<User>(
                    $"Użytkownik {login} już istenie w bazie",
                    true
                    );

            db.Users.Add(new User
            {
                Login = login,
                Password = password,
                Name = name,
                Type = UserType.Participant
            });
            db.SaveChanges();

            return new Response<User>(
                $"Uzytkownik {login} został stworzony",
                false
                );
        }

        public ObservableCollection<User> GetUsers()
        {
            db.Users.Load();
            return db.Users.Local;
        }
    }
}
