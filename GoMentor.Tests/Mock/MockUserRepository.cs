using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Tests.Mock
{
    public class MockUserRepository : IUserRepository
    {
        List<UserModel> _users = new List<UserModel>();
        Dictionary<int, string> _passHashes = new Dictionary<int, string>();
        public void AddRole(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public UserModel Create(UserModel model)
        {
            //Assign UserId
            if (!_users.Any())
            {
                model.UserId = 1;
            }
            else
            {
                var max = _users.Max(u => u.UserId);
                model.UserId = max + 1;
            }
            _users.Add(model);
            return model;
        }

        public ICollection<CategoryModel> GetCategories()
        {
            return new List<CategoryModel>();

        }

        public UserModel GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public UserModel GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public void SetPasswordHash(int userId, string passwordHash)
        {
            if (_passHashes.ContainsKey(userId))
            {
                _passHashes[userId] = passwordHash;
            }

            else
            {
                _passHashes.Add(userId, passwordHash);
            }
        }

        public UserModel ValidateUser(string email, string passwordHash)
        {
            var user = _users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                var passHash = _passHashes[user.UserId];
                if (passHash == passwordHash)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
