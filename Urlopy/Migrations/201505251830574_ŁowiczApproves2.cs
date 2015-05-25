namespace Urlopy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ŁowiczApproves2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Holidays", name: "User_Id", newName: "ApplicationUser_Id");
            AddColumn("dbo.Holidays", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Holidays", "User");
            RenameColumn(table: "dbo.Holidays", name: "ApplicationUser_Id", newName: "User_Id");
        }
    }
}
