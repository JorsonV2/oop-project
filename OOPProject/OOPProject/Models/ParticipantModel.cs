using OOPProject.Db;
using OOPProject.Db.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace OOPProject.Models
{
    public class ParticipantModel
    {
        public ParticipantModel(User user)
        {
            using (var db = new ActivitiesContext())
            {
                db.Users.Where(u => u.Login == user.Login).Load();
            }
        }

        public ICollection<Activitie> GetNotSignedInActivities(User user)
        {
            using (var db = new ActivitiesContext())
            {

                var activities = db.Users.Select(u => u.Activities).FirstOrDefault();

                var users = db.Users
                    .Find(user.Login)
                    .Activities.ToList();


                MessageBox.Show(users.Count().ToString());

                return db.Activities.Where(a => !activities.Contains(a)).ToList();
            }
        }

        public List<ObservableCollection<Activitie>> GetSignedInAndInQueueActivities(User user)
        {
            using (var db = new ActivitiesContext())
            {
                var signed = new ObservableCollection<Activitie>();
                var queue = new ObservableCollection<Activitie>();

                foreach (var a in db.Users.Find(user.Login).Activities.ToList())
                {
                    var userFound = db.Users.Find(user.Login);

                    if (a.ActivitiesParticipants.OrderByDescending(ap => ap.SignUpDate)
                        .Take(a.ParticipantsNumber).ToList()
                        .Where(ap => ap.ParticipantLogin == user.Login).Count() > 0)

                        signed.Add(a);

                    else
                        queue.Add(a);
                    /*
                    var isInQueue = true;

                    foreach (var ap in a.ActivitiesParticipants.OrderByDescending(ap => ap.SignUpDate).Take(a.ParticipantsNumber).ToList())
                        if (ap.User == user)
                        {
                            signed.Add(a);
                            isInQueue = false;
                            break;
                        }

                    if (isInQueue)
                        queue.Add(a);
                    
                     */
                }
                var list = new List<ObservableCollection<Activitie>>();
                list.Add(signed);
                list.Add(queue);
                return list;
            }
        }

        public Response<ActivitieParticipant> SignIn(Activitie activitie, User user)
        {
            using (var db = new ActivitiesContext())
            {
                db.ActivitiesParticipants.Add(new ActivitieParticipant
                {
                    ActivitieId = activitie.ActivitieId,
                    ParticipantLogin = user.Login,
                    SignUpDate = DateTime.Now
                });

                db.SaveChanges();

                return new Response<ActivitieParticipant>(
                    $"Zostałeś zapisany na zajęcia",
                    false
                    );
            }
        }

        public Response<ActivitieParticipant> SignOut(Activitie activitie, User user)
        {
            using (var db = new ActivitiesContext())
            {

                db.ActivitiesParticipants.Remove(activitie.ActivitiesParticipants.TakeWhile(ap => ap.ActivitieId == activitie.ActivitieId && ap.ParticipantLogin == user.Login).First());
                db.SaveChanges();

                return new Response<ActivitieParticipant>(
                    $"Zostałeś wypisany/na z zajęć",
                    false
                    );
            }
        }
    }
}
