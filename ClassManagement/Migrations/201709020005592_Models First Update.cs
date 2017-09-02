namespace ClassManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsFirstUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        CourseID = c.Int(nullable: false),
                        Grade = c.Int(),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreditLoad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropIndex("dbo.Enrollments", new[] { "UserID" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Courses");
            DropTable("dbo.Enrollments");
        }
    }
}
