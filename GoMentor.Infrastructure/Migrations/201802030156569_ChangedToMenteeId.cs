namespace GoMentor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedToMenteeId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Schedules", name: "UserId", newName: "MenteeId");
            RenameIndex(table: "dbo.Schedules", name: "IX_UserId", newName: "IX_MenteeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Schedules", name: "IX_MenteeId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Schedules", name: "MenteeId", newName: "UserId");
        }
    }
}
