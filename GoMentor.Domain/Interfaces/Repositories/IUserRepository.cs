using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        UserModel ValidateUser(string email, string password);
        UserModel GetUserByEmail(string email);
        UserModel GetUserById(int userId);
        UserModel Create(UserModel model);
        void SetPasswordHash(int userId, string passwordHash);
        ICollection<CategoryModel> GetCategories();
        void AddRole(int userId, int roleId);
    }
}
