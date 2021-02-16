using OOPProject.Db;
using OOPProject.Db.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Models
{
    public class RegisterModel
    {
        public Response<User> RegisterParticipant(string login, string password, string name)
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
                    Type = UserType.Participant
                });
                db.SaveChanges();

                return new Response<User>(
                    $"Uzytkownik {login} został stworzony",
                    false
                    );

            }
        }
    }
}
