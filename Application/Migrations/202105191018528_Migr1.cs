namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "SubjId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Requests", "SubjId", c => c.String());
        }
    }
}
