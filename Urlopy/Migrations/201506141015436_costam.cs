namespace Urlopy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class costam : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "pageStyle");
            AddColumn("dbo.AspNetUsers", "pageStyle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "pageStyle");
        }
    }
}
