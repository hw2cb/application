namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewwArchitectureBd4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "SubjId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "SubjId");
        }
    }
}
