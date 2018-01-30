namespace GoMentor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyForUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "Mentee_UserId", "dbo.Mentees");
            DropIndex("dbo.Schedules", new[] { "Mentee_UserId" });
            RenameColumn(table: "dbo.Schedules", name: "Mentee_UserId", newName: "UserId");
            AlterColumn("dbo.Schedules", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "UserId");
            AddForeignKey("dbo.Schedules", "UserId", "dbo.Mentees", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "UserId", "dbo.Mentees");
            DropIndex("dbo.Schedules", new[] { "UserId" });
            AlterColumn("dbo.Schedules", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Schedules", name: "UserId", newName: "Mentee_UserId");
            CreateIndex("dbo.Schedules", "Mentee_UserId");
            AddForeignKey("dbo.Schedules", "Mentee_UserId", "dbo.Mentees", "UserId");
        }
    }
}
