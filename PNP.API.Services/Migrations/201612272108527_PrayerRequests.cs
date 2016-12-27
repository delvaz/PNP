namespace PNP.API.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrayerRequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrayerRequests",
                c => new
                    {
                        PrayerRequestId = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        TargetDate = c.DateTime(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                        CloseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PrayerRequestId);
            
            CreateTable(
                "dbo.PrayerRequestGroups",
                c => new
                    {
                        PrayerRequestId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PrayerRequestId, t.GroupId })
                .ForeignKey("dbo.PrayerRequests", t => t.PrayerRequestId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.PrayerRequestId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrayerRequestGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.PrayerRequestGroups", "PrayerRequestId", "dbo.PrayerRequests");
            DropIndex("dbo.PrayerRequestGroups", new[] { "GroupId" });
            DropIndex("dbo.PrayerRequestGroups", new[] { "PrayerRequestId" });
            DropTable("dbo.PrayerRequestGroups");
            DropTable("dbo.PrayerRequests");
        }
    }
}
