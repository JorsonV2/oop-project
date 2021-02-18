namespace OOPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivitieId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ParticipantsNumber = c.Int(nullable: false),
                        LeaderLogin = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ActivitieId)
                .ForeignKey("dbo.Users", t => t.LeaderLogin)
                .Index(t => t.LeaderLogin);
            
            CreateTable(
                "dbo.ActivitieParticipants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivitieId = c.Int(nullable: false),
                        ParticipantLogin = c.String(maxLength: 128),
                        SignUpDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivitieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ParticipantLogin)
                .Index(t => t.ActivitieId)
                .Index(t => t.ParticipantLogin);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Login);
            
            CreateTable(
                "dbo.ParticipantDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParticipantLogin = c.String(maxLength: 128),
                        LeaderLogin = c.String(maxLength: 128),
                        Description = c.String(),
                        User_Login = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.LeaderLogin)
                .ForeignKey("dbo.Users", t => t.ParticipantLogin)
                .ForeignKey("dbo.Users", t => t.User_Login)
                .Index(t => t.ParticipantLogin)
                .Index(t => t.LeaderLogin)
                .Index(t => t.User_Login);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParticipantDescriptions", "User_Login", "dbo.Users");
            DropForeignKey("dbo.ParticipantDescriptions", "ParticipantLogin", "dbo.Users");
            DropForeignKey("dbo.ParticipantDescriptions", "LeaderLogin", "dbo.Users");
            DropForeignKey("dbo.ActivitieParticipants", "ParticipantLogin", "dbo.Users");
            DropForeignKey("dbo.Activities", "LeaderLogin", "dbo.Users");
            DropForeignKey("dbo.ActivitieParticipants", "ActivitieId", "dbo.Activities");
            DropIndex("dbo.ParticipantDescriptions", new[] { "User_Login" });
            DropIndex("dbo.ParticipantDescriptions", new[] { "LeaderLogin" });
            DropIndex("dbo.ParticipantDescriptions", new[] { "ParticipantLogin" });
            DropIndex("dbo.ActivitieParticipants", new[] { "ParticipantLogin" });
            DropIndex("dbo.ActivitieParticipants", new[] { "ActivitieId" });
            DropIndex("dbo.Activities", new[] { "LeaderLogin" });
            DropTable("dbo.ParticipantDescriptions");
            DropTable("dbo.Users");
            DropTable("dbo.ActivitieParticipants");
            DropTable("dbo.Activities");
        }
    }
}
