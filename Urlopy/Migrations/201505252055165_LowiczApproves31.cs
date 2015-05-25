namespace Urlopy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LowiczApproves31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Holidays", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Holidays", "UserID");
        }
    }
}
