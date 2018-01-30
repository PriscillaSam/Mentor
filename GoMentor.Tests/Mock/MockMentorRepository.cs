using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Tests.Mock
{
    public class MockMentorRepository : IMentorRepository
    {
        List<MentorModel> Mentors = new List<MentorModel>();
        public void AddMentor(MentorModel model)
        {
            var mentor = new MentorModel
            {
                UserId = model.UserId,
                Category = model.Category
            };

        

            Mentors.Add(mentor);
           

        }

        public MentorModel EditMentor(MentorModel model, int userId)
        {
            throw new NotImplementedException();
        }

        public MentorModel GetMentor(int id)
        {
            return Mentors.FirstOrDefault(u => u.UserId == id);


            
            
        }

        public UserModel[] GetMentors()
        {
            throw new NotImplementedException();
        }

        public MentorModel[] GetMentorsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public MentorModel[] GetMentorsByCategory(string category)
        {
            throw new NotImplementedException();
        }
    }
}
