namespace GoMentor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        Image = c.String(),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.Role_RoleId);
            
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
                        Mentee_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ForumId)
                .ForeignKey("dbo.Mentees", t => t.Mentee_UserId)
                .Index(t => t.Mentee_UserId);
            
            CreateTable(
                "dbo.Mentees",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Street = c.String(),
                        CIty = c.String(),
                        State = c.String(),
                        MobileNo = c.String(),
                        Bio = c.String(),
                        Category_CategoryId = c.Int(),
                        Mentor_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Mentors", t => t.Mentor_UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Mentor_UserId);
            
            CreateTable(
                "dbo.Mentors",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        MobileNo = c.String(),
                        Bio = c.String(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        MeetingDetails = c.String(),
                        Mentee_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Mentees", t => t.Mentee_UserId)
                .Index(t => t.Mentee_UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        TIme = c.DateTime(nullable: false),
                        Forum_ForumId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Fora", t => t.Forum_ForumId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Forum_ForumId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Post_PostId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Posts", t => t.Post_PostId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Post_PostId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Replies", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Replies", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Forum_ForumId", "dbo.Fora");
            DropForeignKey("dbo.Fora", "Mentee_UserId", "dbo.Mentees");
            DropForeignKey("dbo.Mentees", "UserId", "dbo.Users");
            DropForeignKey("dbo.Schedules", "Mentee_UserId", "dbo.Mentees");
            DropForeignKey("dbo.Mentors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Mentees", "Mentor_UserId", "dbo.Mentors");
            DropForeignKey("dbo.Mentors", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Mentees", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Admins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Replies", new[] { "User_UserId" });
            DropIndex("dbo.Replies", new[] { "Post_PostId" });
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            DropIndex("dbo.Posts", new[] { "Forum_ForumId" });
            DropIndex("dbo.Schedules", new[] { "Mentee_UserId" });
            DropIndex("dbo.Mentors", new[] { "Category_CategoryId" });
            DropIndex("dbo.Mentors", new[] { "UserId" });
            DropIndex("dbo.Mentees", new[] { "Mentor_UserId" });
            DropIndex("dbo.Mentees", new[] { "Category_CategoryId" });
            DropIndex("dbo.Mentees", new[] { "UserId" });
            DropIndex("dbo.Fora", new[] { "Mentee_UserId" });
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            DropIndex("dbo.Admins", new[] { "UserId" });
            DropTable("dbo.Replies");
            DropTable("dbo.Posts");
            DropTable("dbo.Schedules");
            DropTable("dbo.Mentors");
            DropTable("dbo.Mentees");
            DropTable("dbo.Fora");
            DropTable("dbo.Donations");
            DropTable("dbo.Categories");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Admins");
        }
    }
}
