namespace GoMentor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GoMentor.Infrastructure.Entities.DataEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GoMentor.Infrastructure.Entities.DataEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            //Adding Roles
            context.Roles.AddOrUpdate(r => r.Name,
                new Entities.Role
                {
                    Name = "Admin"
                },
                new Entities.Role
                {
                    Name = "Mentor"
                },
                new Entities.Role
                {
                    Name = "Mentee"
                }
            );

            //Adding Users
            context.Users.AddOrUpdate(
                new Entities.User
                {
                    Email = "priscillasamiduh@gmail.com",
                    Password = "password",
                    FirstName = "Priscilla",
                    LastName = "Sam-Iduh"
                                  
                });
        }
    }
}
