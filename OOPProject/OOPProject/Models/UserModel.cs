using OOPProject.Db;
using OOPProject.Db.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Models
{
    public abstract class UserModel
    {
        protected ActivitiesContext db;

        public UserModel()
        {
            db = new ActivitiesContext();
        }

        public Response<User> EditUser(User user, string password, string name)
        {
            var editedUser = db.Users.Find(user.Login);

            if (editedUser is null)
                return new Response<User>(
                    $"Użutkownik {user.Login} nie istnieje w bazie",
                    true
                    );

            editedUser.Password = password;
            editedUser.Name = name;

            db.SaveChanges();

            return new Response<User>(
                $"Użytkownik {user.Login} został zedytowany",
                false
                );
        }
    }
}
