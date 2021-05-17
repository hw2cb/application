namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "Request_Id", "dbo.Requests");
            DropIndex("dbo.Subjects", new[] { "Request_Id" });
            AddColumn("dbo.Requests", "SubjectId", c => c.Int(nullable: false));
            DropColumn("dbo.Subjects", "Request_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Request_Id", c => c.Int());
            DropColumn("dbo.Requests", "SubjectId");
            CreateIndex("dbo.Subjects", "Request_Id");
            AddForeignKey("dbo.Subjects", "Request_Id", "dbo.Requests", "Id");
        }
    }
}
