using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    public class Model
    {
        private ActivitiesContext db;

        public Model()
        {
            db = new ActivitiesContext();
            var admins = db.Users
                .Where(u => u.Type == UserType.Admin)
                .ToArray();

            if (admins.Length == 0)
            {
                db.Users.Add(new User { 
                    Login = "root",
                    Password = "root",
                    Name = "root",
                    Type = UserType.Admin
                });

                db.SaveChanges();
            }
        }
    }
}
