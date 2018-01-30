namespace GoMentor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyConstraint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mentors", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Mentors", new[] { "Category_CategoryId" });
            RenameColumn(table: "dbo.Mentors", name: "Category_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.Mentors", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Mentors", "CategoryId");
            AddForeignKey("dbo.Mentors", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mentors", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Mentors", new[] { "CategoryId" });
            AlterColumn("dbo.Mentors", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Mentors", name: "CategoryId", newName: "Category_CategoryId");
            CreateIndex("dbo.Mentors", "Category_CategoryId");
            AddForeignKey("dbo.Mentors", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
