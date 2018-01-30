namespace GoMentor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedules", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedules", "Details", c => c.String());
            DropColumn("dbo.Schedules", "MeetingDetails");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "MeetingDetails", c => c.String());
            DropColumn("dbo.Schedules", "Details");
            DropColumn("dbo.Schedules", "Time");
            DropColumn("dbo.Schedules", "Date");
        }
    }
}
