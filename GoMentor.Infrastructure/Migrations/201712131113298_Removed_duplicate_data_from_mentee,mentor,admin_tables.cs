namespace GoMentor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_duplicate_data_from_menteementoradmin_tables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Image", c => c.String());
            DropColumn("dbo.Admins", "FirstName");
            DropColumn("dbo.Admins", "LastName");
            DropColumn("dbo.Admins", "Email");
            DropColumn("dbo.Admins", "Password");
            DropColumn("dbo.Mentors", "FirstName");
            DropColumn("dbo.Mentors", "LastName");
            DropColumn("dbo.Mentors", "Image");
            DropColumn("dbo.Mentors", "Email");
            DropColumn("dbo.Mentees", "FirstName");
            DropColumn("dbo.Mentees", "LastName");
            DropColumn("dbo.Mentees", "Email");
            DropColumn("dbo.Mentees", "Password");
            DropColumn("dbo.Mentees", "Picture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mentees", "Picture", c => c.String());
            AddColumn("dbo.Mentees", "Password", c => c.String());
            AddColumn("dbo.Mentees", "Email", c => c.String());
            AddColumn("dbo.Mentees", "LastName", c => c.String());
            AddColumn("dbo.Mentees", "FirstName", c => c.String());
            AddColumn("dbo.Mentors", "Email", c => c.String());
            AddColumn("dbo.Mentors", "Image", c => c.String());
            AddColumn("dbo.Mentors", "LastName", c => c.String());
            AddColumn("dbo.Mentors", "FirstName", c => c.String());
            AddColumn("dbo.Admins", "Password", c => c.String());
            AddColumn("dbo.Admins", "Email", c => c.String());
            AddColumn("dbo.Admins", "LastName", c => c.String());
            AddColumn("dbo.Admins", "FirstName", c => c.String());
            DropColumn("dbo.Users", "Image");
        }
    }
}
