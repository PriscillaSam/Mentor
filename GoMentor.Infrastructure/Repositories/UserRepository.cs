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
        private DataEntities _context;

        public UserRepository(DataEntities context)
        {
            _context = context;
        }

        public UserModel Create(UserModel model)
        {
            //map UserModel to User
            if (model != null)
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                model.UserId = user.UserId;
            }

            return model;
        }

        public UserModel ValidateUser(string email, string passwordHash)
        {
            // Check if user record exists in database and get it
            var query = from user in _context.Users
                        where user.Email == email
                        where user.PasswordHash == passwordHash
                        select new
                        {
                            user,
                            role = user.Role.Name
                        };

            var record = query.FirstOrDefault();

            if (record != null)
            {
                return new UserModel
                {
                    UserId = record.user.UserId,
                    Email = record.user.Email,
                    FirstName = record.user.FirstName,
                    LastName = record.user.LastName,
                    Role = record.role
                };
            }

            return null;
        }
        public UserModel GetUserById(int userId)
        {
            //Generate query
            var query = from user in _context.Users
                        where user.UserId == userId

                        select new
                        {
                            user,
                            role = user.Role.Name

                        };


            //pull record from database
            var record = query.FirstOrDefault();

            //transform user record if not null
            if (record != null)
            {
                var transform = new UserModel
                {
                    UserId = record.user.UserId,
                    FirstName = record.user.FirstName,
                    LastName = record.user.LastName,
                    Email = record.user.Email,
                    Image = record.user.Image,
                    Role = record.role
                };

                return transform;
            }
            return null;
        }
        public UserModel GetUserByEmail(string email)
        {
            //Generate query
            var query = from user in _context.Users
                        where user.Email == email
                        select new
                        {
                            user,
                            role = user.Role.Name
                        };

            //pull record from database
            var record = query.FirstOrDefault();

            //transform user record if not null
            if (record != null)
            {
                var transform = new UserModel
                {
                    UserId = record.user.UserId,
                    FirstName = record.user.FirstName,
                    LastName = record.user.LastName,
                    Email = record.user.Email,
                    Image = record.user.Image,
                    Role = record.role
                };

                return transform;
            }
            return null;
        }

        public void SetPasswordHash(int userId, string passwordHash)
        {
            // Get user by id
            var user = _context.Users.Find(userId);
            if (user == null)
                throw new Exception("User not found");
            user.PasswordHash = passwordHash;
            _context.SaveChanges();
        }

        public ICollection<CategoryModel> GetCategories()
        {
            var query = from category in _context.Categories
                        orderby category.CategoryName
                        select new CategoryModel
                        {
                            CategoryId = category.CategoryId,
                            CategoryName = category.CategoryName
                        };

            return query.ToArray();
        }

        public void AddRole(int userId, int roleId)
        {
            //Get User by Id         
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var role = _context.Roles.Find(roleId);
            user.Role = role;
            _context.SaveChanges();
        }

    }
    
}
