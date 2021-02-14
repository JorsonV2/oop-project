using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Leader> Leaders { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Activitie> Activities { get; set; }
    }

    public abstract class User
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class Leader : User
    {
        public int LeaderId { get; set; }
    }

    public class Participant : User
    {
        public int ParticipantId { get; set; }
    }

    public class Admin : User
    {
        public int AdminId { get; set; }
    }

    public class Activitie
    {
        public int ActivitieId { get; set; }

        public DateTime StartDateTime { get; set; }
        public TimeSpan DurationTime { get; set; }
        public string Description { get; set; }
        public int ParticipantsLimit { get; set; }
        public virtual List<Participant> Participants { get; set; }
        public int LeaderId { get; set; }
        public virtual Leader Leader { get; set; }

    }

}