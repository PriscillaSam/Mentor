namespace GoMentor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDatetimeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "Date", c => c.String());
            AlterColumn("dbo.Schedules", "Time", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "Date", c => c.DateTime(nullable: false));
        }
    }
}
