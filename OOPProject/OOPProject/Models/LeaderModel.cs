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
    public class LeaderModel : UserModel
    {

        public ObservableCollection<Activitie> GetActivities()
        {
            db.Activities.Load();
            return db.Activities.Local;
        }
    }
}
