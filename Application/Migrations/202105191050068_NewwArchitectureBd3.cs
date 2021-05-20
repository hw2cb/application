namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewwArchitectureBd3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RequestSubjects", "RequestId");
            CreateIndex("dbo.RequestSubjects", "SubjectId");
            AddForeignKey("dbo.RequestSubjects", "RequestId", "dbo.Requests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RequestSubjects", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.RequestSubjects", "RequestId", "dbo.Requests");
            DropIndex("dbo.RequestSubjects", new[] { "SubjectId" });
            DropIndex("dbo.RequestSubjects", new[] { "RequestId" });
        }
    }
}
