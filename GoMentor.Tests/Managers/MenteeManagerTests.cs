using System;
using GoMentor.Domain.Managers;
using GoMentor.Domain.Models;
using GoMentor.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoMentor.Tests.Managers
{
    [TestClass]
    public class MenteeManagerTests
    {
        [TestMethod]
        public void AddMentee()
        {
            //Arrange
            var mockRepo = new MockMenteeRepository();
            var manager = new MenteeManager(mockRepo);
            //Test Data
            var mentee = new MenteeModel
            {
                Bio = "My test bio",
                Address = "Lagos",
                Gender = "Lagos",
            };
            //Act
            manager.AddMentee(mentee, 1);
            //Assert
            Assert.IsTrue(manager.GetMentee(mentee.UserId) != null, "Mentee was not created");
        }

        [TestMethod]
        public void AssignMentor()
        {
            //Arrange
            var mockRepo = new MockMenteeRepository();
            var manager = new MenteeManager(mockRepo);

            //Test Data
            var mentee = new MenteeModel
            {
                Category = "Art"
            };
            //Act
            manager.AddMentee(mentee, 1);
            manager.AssignMentor(mentee, 11);
            //Assert
            Assert.IsTrue(mockRepo.Mentored(mentee.UserId), "Mentor was not assigned");
        }
    }
}
