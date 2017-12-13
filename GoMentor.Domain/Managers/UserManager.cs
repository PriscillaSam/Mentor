using GoMentor.Domain.Interfaces.Repositories;
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

        //Register new user


        public UserManager(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }


        public UserModel RegisterUser(UserModel user)
        {
            //Validate user
            user.Validate();
            //Check if User exists
            //Create User
            return user;
        }

        public UserModel LogIn(string email, string password)
        {
            
            return _userRepo.ValidateUser(email, password);
        }
    }
}
