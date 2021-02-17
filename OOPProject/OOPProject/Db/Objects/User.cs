using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OOPProject.Db.Objects
{
    public enum UserType
    {
        Admin = 0,
        Leader = 1,
        Participant = 2
    }

    public class User
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }

        public virtual ICollection<Activitie> Activities { get; set; }
        public virtual ICollection<ParticipantDescription> ParticipantsDescriptions { get; set; }
        public virtual ICollection<ActivitieParticipant> ActivitiesParticipants { get; set; }

    }
}
