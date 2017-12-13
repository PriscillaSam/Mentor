using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Models;
using GoMentor.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public UserModel ValidateUser(string email, string password)
        {
            // Check if user record exists in database and get it
            var query = from user in _context.Set<User>()
                        where user.Email == email
                        where user.Password == password

                        let roles = from userRole in user.UserRoles
                                    select userRole.Role.Name
                        select new
                        {
                            user,
                            roles
                        };

            var record = query.FirstOrDefault();

            if (record != null)
            {
                return new UserModel
                {
                    Email = record.user.Email,
                    FirstName = record.user.FirstName,
                    LastName = record.user.LastName,
                    Roles = record.roles.ToArray()
                };
            }

            return null;


        }
    }
}
