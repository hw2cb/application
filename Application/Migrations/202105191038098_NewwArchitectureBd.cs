namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewwArchitectureBd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "Request_Id", "dbo.Requests");
            DropIndex("dbo.Subjects", new[] { "Request_Id" });
            DropColumn("dbo.Requests", "SubjId");
            DropColumn("dbo.Subjects", "Request_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Request_Id", c => c.Int());
            AddColumn("dbo.Requests", "SubjId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "Request_Id");
            AddForeignKey("dbo.Subjects", "Request_Id", "dbo.Requests", "Id");
        }
    }
}
