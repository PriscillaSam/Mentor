using System;
using GoMentor.Domain.Managers;
using GoMentor.Domain.Models;
using GoMentor.Infrastructure.Utilities;
using GoMentor.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoMentor.Tests.Managers
{
    [TestClass]
    public class UserManagerTests
    {
        [TestMethod]
        public void RegisterUser()
        {
            //Arrange
            var mockRepo = new MockUserRepository();
            var manager = new UserManager(mockRepo, new MD5Encryption());
            //Test Data
            var user = new UserModel
            {
                Email = "temp.sample@gmail.com",
                FirstName = "Temp",
                LastName = "Sample",
            };

            //Act
            manager.RegisterUser(user, "password");

            //Assert
            Assert.IsTrue(mockRepo.GetUserByEmail(user.Email) != null,"User not added");
            
        }
    }
}
