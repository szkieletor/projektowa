namespace Urlopy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pageStyle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "pageStyle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "pageStyle");
        }
    }
}
