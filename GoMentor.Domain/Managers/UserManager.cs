using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Interfaces.Utilities;
using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Managers
{
    public class UserManager
    {

        private IUserRepository _userRepo;
        private IEncryption _encryption;
        
        public UserManager(IUserRepository userRepo, IEncryption encryption)
        {
            _userRepo = userRepo;
            _encryption = encryption;
        }


        //Register new user
        public UserModel RegisterUser(UserModel model, string password)
        {
            //Validate user
            model.Validate();

            //Check if User already exists
            var user = _userRepo.GetUserByEmail(model.Email);
            if (user != null)
            {
                throw new Exception($"This email ({user.Email}) is already in use");
            }

            //Create User
             user = _userRepo.Create(model);

            //Encrypt Password
            var passwordHash = _encryption.Encrypt(password);

            //Set PasswordHash
            _userRepo.SetPasswordHash(user.UserId, passwordHash);
            return model;
        }

        public UserModel GetUser(string email)
        {
            return _userRepo.GetUserByEmail(email);
        }
        public UserModel LogIn(string email, string password)
        {
            //Encrypt password entered
            var passwordHash = _encryption.Encrypt(password);
            return _userRepo.ValidateUser(email, passwordHash);
        }

        public void AddRole(int userId, int roleId)
        {
            _userRepo.AddRole(userId, roleId);
        }

        public UserModel GetUserById(int userId)
        {
            return _userRepo.GetUserById(userId);
        }
        public IEnumerable<CategoryModel> GetCategories()
        {
            return _userRepo.GetCategories();
        }
    }
}
