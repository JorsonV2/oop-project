using OOPProject.Db.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Models.Interfaces
{
    public interface IActivitieModel
    {
        Response<Activitie> EditActivitie(Activitie activitie, string name, DateTime startDate, DateTime endDate, int participantsNumber);
        Response<Activitie> DeleteActivitie(Activitie activitie);
        Response<Activitie> CreateActivitie(User user, string name, DateTime startDate, DateTime endDate, int participantsNumber);
    }
}
