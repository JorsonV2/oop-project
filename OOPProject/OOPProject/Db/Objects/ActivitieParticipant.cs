using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOPProject.Db.Objects
{
    public class ActivitieParticipant
    {
        [Key]
        public int Id { get; set; }
        public int ActivitieId { get; set; }
        public string ParticipantLogin { get; set; }
        public DateTime SignUpDate { get; set; }

        [ForeignKey("ActivitieId")]
        public virtual Activitie Activitie { get; set; }
        [ForeignKey("ParticipantLogin")]
        public virtual User User { get; set; }

        
    }

}