namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewwArchitectureBd6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "Count");
        }
    }
}
