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
    public class LeaderModel : IUserModel
    {
        private ActivitieContext db;

        public LeaderModel()
        {
            db = new ActivitieContext();
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
