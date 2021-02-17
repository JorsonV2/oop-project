using OOPProject.Db;
using OOPProject.Db.Objects;
using OOPProject.Models.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace OOPProject.Models
{
    public class LeaderModel : IUserModel
    {
        private ActivitiesContext db;

        public LeaderModel()
        {
            db = new ActivitiesContext();
        }

        public Response<User> EditUser(User user, string password, string name)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Activitie> GetActivities()
        {
            db.Activities.Load();
            return db.Activities.Local;
        }
    }
}
