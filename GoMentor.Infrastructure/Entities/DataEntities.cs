using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Infrastructure.Entities
{
    public class DataEntities : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Mentee> Mentees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Forum> Fora { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Donation> Donations { get; set; }
    }
}
