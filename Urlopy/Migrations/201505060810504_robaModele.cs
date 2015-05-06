namespace Urlopy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class robaModele : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HolidayRangeHistories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HolidayRangeID = c.Int(nullable: false),
                        OperationType = c.String(),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        Kind = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HolidayRanges", t => t.HolidayRangeID, cascadeDelete: true)
                .Index(t => t.HolidayRangeID);
            
            CreateTable(
                "dbo.HolidayRanges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HolidayID = c.Int(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        Kind = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Holidays", t => t.HolidayID, cascadeDelete: true)
                .Index(t => t.HolidayID);
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Status = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        LoginFromLdap = c.Int(),
                        Name = c.String(),
                        Surname = c.String(),
                        percentagesOfTime = c.Int(),
                        daysForYear = c.Int(),
                        daysLeft = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Supervisor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Supervisor_Id)
                .Index(t => t.Supervisor_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HolidayRangeHistories", "HolidayRangeID", "dbo.HolidayRanges");
            DropForeignKey("dbo.AspNetUsers", "Supervisor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Holidays", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HolidayRanges", "HolidayID", "dbo.Holidays");
            DropIndex("dbo.HolidayRangeHistories", new[] { "HolidayRangeID" });
            DropIndex("dbo.AspNetUsers", new[] { "Supervisor_Id" });
            DropIndex("dbo.Holidays", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.HolidayRanges", new[] { "HolidayID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Holidays");
            DropTable("dbo.HolidayRanges");
            DropTable("dbo.HolidayRangeHistories");
        }
    }
}
