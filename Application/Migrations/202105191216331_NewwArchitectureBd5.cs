namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewwArchitectureBd5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RequestSubjects", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.RequestSubjects", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.RequestSubjects", new[] { "RequestId" });
            DropIndex("dbo.RequestSubjects", new[] { "SubjectId" });
            RenameColumn(table: "dbo.RequestSubjects", name: "RequestId", newName: "Request_Id");
            RenameColumn(table: "dbo.RequestSubjects", name: "SubjectId", newName: "Subject_Id");
            AlterColumn("dbo.RequestSubjects", "Request_Id", c => c.Int());
            AlterColumn("dbo.RequestSubjects", "Subject_Id", c => c.Int());
            CreateIndex("dbo.RequestSubjects", "Request_Id");
            CreateIndex("dbo.RequestSubjects", "Subject_Id");
            AddForeignKey("dbo.RequestSubjects", "Request_Id", "dbo.Requests", "Id");
            AddForeignKey("dbo.RequestSubjects", "Subject_Id", "dbo.Subjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.RequestSubjects", "Request_Id", "dbo.Requests");
            DropIndex("dbo.RequestSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.RequestSubjects", new[] { "Request_Id" });
            AlterColumn("dbo.RequestSubjects", "Subject_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.RequestSubjects", "Request_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.RequestSubjects", name: "Subject_Id", newName: "SubjectId");
            RenameColumn(table: "dbo.RequestSubjects", name: "Request_Id", newName: "RequestId");
            CreateIndex("dbo.RequestSubjects", "SubjectId");
            CreateIndex("dbo.RequestSubjects", "RequestId");
            AddForeignKey("dbo.RequestSubjects", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RequestSubjects", "RequestId", "dbo.Requests", "Id", cascadeDelete: true);
        }
    }
}
