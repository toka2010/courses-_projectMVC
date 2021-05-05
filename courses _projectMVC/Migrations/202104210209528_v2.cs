namespace courses__projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Type");
        }
    }
}
