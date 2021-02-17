using OOPProject.Db;
using OOPProject.Db.Objects;
using OOPProject.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Models
{
    public class AdminModel : IUserModel
    {

        public Response<User> CreateUser(string login, string password, string name, UserType userType)
        {
            using (var db = new ActivitiesContext())
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
                    Type = userType
                });
                db.SaveChanges();

                return new Response<User>(
                    $"Uzytkownik {login} został stworzony",
                    false
                    );
            }
            

            
        }

        public ObservableCollection<User> GetUsers()
        {
            using (var db = new ActivitiesContext())
            {
                db.Users.Load();
                return db.Users.Local;
            }
            
        }

        public ObservableCollection<Activitie> GetActivities()
        {
            using (var db = new ActivitiesContext())
            {
                db.Activities.Load();
                return db.Activities.Local;
            }
            
        }

        public ObservableCollection<ActivitieParticipant> GetActivitiesParticipants()
        {
            using (var db = new ActivitiesContext())
            {
                db.ActivitiesParticipants.Load();
                return db.ActivitiesParticipants.Local;
            }
            
        }

        public Response<User> DeleteUser(string login)
        {
            using (var db = new ActivitiesContext())
            {
                var user = db.Users.Find(login);

                if (user is null)
                    return new Response<User>(
                        $"Nie ma takiego użytkownika jak {login}",
                        true
                        );

                db.Users.Remove(user);
                db.SaveChanges();

                return new Response<User>(
                    $"Użytkownik {login} został usunięty",
                    false
                    );
            } 
        }

        public Response<User> EditUser(User user, string password, string name)
        {
            using (var db = new ActivitiesContext())
            {
                var editedUser = db.Users.Find(user.Login);

                if (editedUser is null)
                    return new Response<User>(
                        $"Użutkownik {user.Login} nie istnieje w bazie",
                        true
                        );

                editedUser.Password = password;
                editedUser.Name = name;

                db.Users.Add(editedUser);
                db.Entry(editedUser).State = EntityState.Modified;

                db.SaveChanges();

                return new Response<User>(
                    $"Użytkownik {user.Login} został zedytowany",
                    false
                    );
            }
        }
    }
}
