using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOPProject
{
    public class ActivitiesContext : DbContext
    {
        // Your context has been configured to use a 'ActivitiesContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'OOPProject.ActivitiesContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ActivitiesContext' 
        // connection string in the application configuration file.
        public ActivitiesContext()
            : base("name=ActivitiesContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Activitie> Activities { get; set; }
        public virtual DbSet<ActivitieParticipant> ActivitiesParticipants { get; set; }
        public virtual DbSet<ParticipantDescription> ParticipantsDescriptions { get; set; }

    }

    public enum UserType
    {
        Admin,
        Leader,
        Participant
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

    public class Activitie
    {
        [Key]
        public int ActivitieId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public int ParticipantsNumber { get; set; }
        public string LeaderLogin { get; set; }

        [ForeignKey("LeaderLogin")]
        public virtual User User { get; set; }
        public virtual ICollection<ActivitieParticipant> ActivitiesParticipants { get; set; }
    }

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