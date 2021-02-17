using OOPProject.Db;
using OOPProject.Db.Objects;
using OOPProject.Models.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace OOPProject.Models
{
    public class LeaderModel : IUserModel, IActivitieModel
    {

        public Response<User> EditUser(User user, string password, string name)
        {
            throw new NotImplementedException();
        }

        public Response<Activitie> CreateActivitie(User user, string name, DateTime startDate, DateTime endDate, int participantsNumber)
        {
            using (var db = new ActivitiesContext())
            {
                var activitiesOverlaping = db.Activities
                    .Where(a => a.LeaderLogin == user.Login)
                    .Where(a => !(a.StartDate > endDate || a.EndDate < startDate));

                if (activitiesOverlaping.Count() > 0)
                    return new Response<Activitie>(
                        $"Posiadasz {activitiesOverlaping.Count()} inne zajęcia w tym terminie",
                        true,
                        activitiesOverlaping.ToList()
                        );

                db.Activities.Add(new Activitie
                {
                    Name = name,
                    StartDate = startDate,
                    EndDate = endDate,
                    ParticipantsNumber = participantsNumber,
                    LeaderLogin = user.Login
                });

                db.SaveChanges();

                return new Response<Activitie>(
                    $"Udało się zmieścić w grafiku twoje nowe zajęcia",
                    false
                    );
            }
        }

        public ObservableCollection<Activitie> GetActivities(User user)
        {
            using (var db = new ActivitiesContext())
            {
                db.Activities.Where(a => a.LeaderLogin == user.Login).Load();
                return db.Activities.Local;
            }
        }

        public Response<Activitie> EditActivitie(Activitie activitie, string name, DateTime startDate, DateTime endDate, int participantsNumber)
        {
            using (var db = new ActivitiesContext())
            {
                var activitiesOverlaping = db.Activities
                    .Where(a => a.LeaderLogin == activitie.User.Login)
                    .Where(a => !(a.StartDate > endDate || a.EndDate < startDate));

                if (activitiesOverlaping.Count() > 0)
                    return new Response<Activitie>(
                        $"Posiadasz {activitiesOverlaping.Count()} inne zajęcia w tym terminie",
                        true,
                        activitiesOverlaping.ToList()
                        );

                var editedActivitie = db.Activities.Find(activitie);

                editedActivitie.Name = name;
                editedActivitie.StartDate = startDate;
                editedActivitie.EndDate = endDate;
                editedActivitie.ParticipantsNumber = participantsNumber;

                db.Activities.Add(editedActivitie);
                db.Entry(editedActivitie).State = EntityState.Modified;

                db.SaveChanges();

                return new Response<Activitie>(
                    $"Zajęcia zostały zaktualizowane",
                    false
                    );
            }
        }

        public Response<Activitie> DeleteActivitie(Activitie activitie)
        {
            throw new NotImplementedException();
        }
    }
}
