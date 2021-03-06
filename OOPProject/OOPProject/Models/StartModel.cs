﻿using OOPProject.Db;
using OOPProject.Db.Objects;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OOPProject.Models
{
    public class StartModel
    {
        public StartModel()
        {
            using (var db = new ActivitiesContext())
            {
                db.Users.Where(u => u.Type == UserType.Admin).Load();

                if (db.Users.ToList().Count() == 0)
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
