namespace Urlopy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ŁowiczApproves : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Holidays", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Holidays", "UserID", c => c.Int(nullable: false));
        }
    }
}
