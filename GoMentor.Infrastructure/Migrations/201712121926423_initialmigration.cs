namespace GoMentor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Mentors",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Image = c.String(),
                        MobileNo = c.String(),
                        Email = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Mentees",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        CIty = c.String(),
                        State = c.String(),
                        Picture = c.String(),
                        PersonalInfo = c.String(),
                        MentorId = c.Int(nullable: false),
                        Mentor_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Mentors", t => t.Mentor_UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Mentor_UserId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        MeetingDetails = c.String(),
                        MenteeId = c.Int(nullable: false),
                        Mentee_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Mentees", t => t.Mentee_UserId)
                .Index(t => t.Mentee_UserId);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        DonationId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DonationId);
            
            CreateTable(
                "dbo.Fora",
                c => new
                    {
                        ForumId = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        MenteeId = c.Int(nullable: false),
                        Mentee_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ForumId)
                .ForeignKey("dbo.Mentees", t => t.Mentee_UserId)
                .Index(t => t.Mentee_UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        ForumId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        TIme = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Fora", t => t.ForumId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ForumId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Replies", "UserId", "dbo.Users");
            DropForeignKey("dbo.Replies", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "ForumId", "dbo.Fora");
            DropForeignKey("dbo.Fora", "Mentee_UserId", "dbo.Mentees");
            DropForeignKey("dbo.Mentors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Mentees", "UserId", "dbo.Users");
            DropForeignKey("dbo.Schedules", "Mentee_UserId", "dbo.Mentees");
            DropForeignKey("dbo.Mentees", "Mentor_UserId", "dbo.Mentors");
            DropForeignKey("dbo.Mentors", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.Replies", new[] { "UserId" });
            DropIndex("dbo.Replies", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "ForumId" });
            DropIndex("dbo.Fora", new[] { "Mentee_UserId" });
            DropIndex("dbo.Schedules", new[] { "Mentee_UserId" });
            DropIndex("dbo.Mentees", new[] { "Mentor_UserId" });
            DropIndex("dbo.Mentees", new[] { "UserId" });
            DropIndex("dbo.Mentors", new[] { "CategoryId" });
            DropIndex("dbo.Mentors", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Admins", new[] { "UserId" });
            DropTable("dbo.Replies");
            DropTable("dbo.Posts");
            DropTable("dbo.Fora");
            DropTable("dbo.Donations");
            DropTable("dbo.Schedules");
            DropTable("dbo.Mentees");
            DropTable("dbo.Mentors");
            DropTable("dbo.Categories");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Admins");
        }
    }
}
