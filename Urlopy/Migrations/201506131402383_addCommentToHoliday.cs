namespace Urlopy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommentToHoliday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Holidays", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Holidays", "Comment");
        }
    }
}
