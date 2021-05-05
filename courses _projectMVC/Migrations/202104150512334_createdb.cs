namespace courses__projectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        Coursedescription = c.String(nullable: false),
                        WhatCourseLearn1 = c.String(nullable: false),
                        WhatCourseLearn2 = c.String(),
                        WhatCourseLearn3 = c.String(),
                        Price = c.Int(nullable: false),
                        NofArticles = c.Int(nullable: false),
                        NofHoures = c.Int(nullable: false),
                        image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Course_id = c.Int(nullable: false),
                        Reservation_Date = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Reservations");
            DropTable("dbo.Courses");
            DropTable("dbo.ContactUs");
        }
    }
}
