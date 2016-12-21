namespace PNP.API.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Groups1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        ModeratorId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.AspNetUsers", t => t.ModeratorId, cascadeDelete: false)
                .Index(t => t.ModeratorId);

            CreateTable(
                "dbo.AspNetUserGroups",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.GroupId })
                .ForeignKey("dbo.AspNetUsers", t => t.Id, cascadeDelete: false)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: false)
                .Index(t => t.Id)
                .Index(t => t.GroupId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.AspNetUserGroups", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Groups", "ModeratorId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserGroups", new[] { "GroupId" });
            DropIndex("dbo.AspNetUserGroups", new[] { "Id" });
            DropIndex("dbo.Groups", new[] { "ModeratorId" });
            DropTable("dbo.AspNetUserGroups");
            DropTable("dbo.Groups");
        }
    }
}
