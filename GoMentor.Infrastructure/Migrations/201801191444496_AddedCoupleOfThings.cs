namespace GoMentor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCoupleOfThings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mentees", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.Mentees", "Gender", c => c.String());
            AddColumn("dbo.Mentees", "Address", c => c.String());
            AddColumn("dbo.Mentors", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.Mentors", "Gender", c => c.String());
            AddColumn("dbo.Mentors", "Address", c => c.String());
            DropColumn("dbo.Mentees", "Street");
            DropColumn("dbo.Mentees", "CIty");
            DropColumn("dbo.Mentees", "State");
            DropColumn("dbo.Mentors", "Street");
            DropColumn("dbo.Mentors", "City");
            DropColumn("dbo.Mentors", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mentors", "State", c => c.String());
            AddColumn("dbo.Mentors", "City", c => c.String());
            AddColumn("dbo.Mentors", "Street", c => c.String());
            AddColumn("dbo.Mentees", "State", c => c.String());
            AddColumn("dbo.Mentees", "CIty", c => c.String());
            AddColumn("dbo.Mentees", "Street", c => c.String());
            DropColumn("dbo.Mentors", "Address");
            DropColumn("dbo.Mentors", "Gender");
            DropColumn("dbo.Mentors", "Birthday");
            DropColumn("dbo.Mentees", "Address");
            DropColumn("dbo.Mentees", "Gender");
            DropColumn("dbo.Mentees", "Birthday");
        }
    }
}
