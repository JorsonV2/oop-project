using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOPProject.Db.Objects
{
    public class Activitie
    {
        [Key]
        public int ActivitieId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ParticipantsNumber { get; set; }
        public string LeaderLogin { get; set; }

        [ForeignKey("LeaderLogin")]
        public virtual User User { get; set; }
        public virtual ICollection<ActivitieParticipant> ActivitiesParticipants { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
