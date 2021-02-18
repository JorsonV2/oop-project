using OOPProject.Db;
using OOPProject.Db.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPProject.Models
{
    class LoginModel
    {
        public Response<User> ConfirmUser(string login, string password)
        {
            using (var db = new ActivitiesContext())
            {
                var user = db.Users.Find(login);
                if (user is null)
                    return new Response<User>(
                        $"Użytkownik o Login {login} nie został znaleziony",
                        true
                        );

                if (user.Password == password)
                {
                    return new Response<User>(
                        $"Użytkownik {login} został potwierdzony",
                        false,
                        new List<User>().Append(user).ToList()
                        );
                }
                    
                return new Response<User>(
                    "Nieprawidłowe hasło",
                    true
                    );
            }
        }
    }
}
