using OOPProject.Db;
using OOPProject.Db.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Models
{
    public class StartModel
    {
        public StartModel()
        {
            using (var db = new ActivitiesContext())
            {
                var admins = db.Users
                .Where(u => u.Type == UserType.Admin)
                .ToArray();

                if (admins.Length == 0)
                {
                    db.Users.Add(new User
                    {
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

    public class Response<T>
    {
        public Response(string message, bool error, List<T> data = null)
        {
            Message = message;
            Error = error;
            Data = data;
        }

        public string Message { get; set; }
        public bool Error { get; set; }
        public List<T> Data { get; set; }
    }
}
