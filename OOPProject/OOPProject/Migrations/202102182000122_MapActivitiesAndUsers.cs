namespace OOPProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapActivitiesAndUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivitiesParticipants",
                c => new
                    {
                        ActivitieId = c.Int(nullable: false),
                        ParticipantId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ActivitieId, t.ParticipantId })
                .ForeignKey("dbo.Activities", t => t.ActivitieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ParticipantId, cascadeDelete: true)
                .Index(t => t.ActivitieId)
                .Index(t => t.ParticipantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivitiesParticipants", "ParticipantId", "dbo.Users");
            DropForeignKey("dbo.ActivitiesParticipants", "ActivitieId", "dbo.Activities");
            DropIndex("dbo.ActivitiesParticipants", new[] { "ParticipantId" });
            DropIndex("dbo.ActivitiesParticipants", new[] { "ActivitieId" });
            DropTable("dbo.ActivitiesParticipants");
        }
    }
}
