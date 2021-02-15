using System.Data.Entity;

namespace OOPProject.Db
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

}