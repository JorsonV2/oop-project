using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOPProject.Db.Objects
{
    public class ParticipantDescription
    {
        [Key]
        public int Id { get; set; }
        public string ParticipantLogin { get; set; }
        public string LeaderLogin { get; set; }
        public string Description { get; set; }

        [ForeignKey("ParticipantLogin")]
        public virtual User Participant { get; set; }
        [ForeignKey("LeaderLogin")]
        public virtual User Leader { get; set; }
    }

}