namespace GoMentor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ALotChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mentors", "Street", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mentors", "Street");
        }
    }
}
