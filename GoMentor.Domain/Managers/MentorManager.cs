using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Managers
{
    public class MentorManager
    {
        private IMentorRepository _repo;
        public MentorManager(IMentorRepository repo)
        {
            _repo = repo;
        }
        public MentorModel GetMentor(int userId )
        {
            return _repo.GetMentor(userId);
        }

        public void AddMentor(MentorModel model)
        {
            //validate model
            model.Validate();

            //Check if mentor record already exists
            var mentor = _repo.GetMentor(model.UserId);

            if(mentor != null)
            {
                throw new Exception("This record already exists!!!");
            }
            _repo.AddMentor(model);

        }

        public void EditMentor(MentorModel model, int userId)
        {
            _repo.EditMentor(model, userId);
        }
        public MentorModel[] GetMentors()
        {
            var mentorList = _repo.GetMentors();
            return mentorList.ToArray();
        }

        public MentorModel[] GetMentorsByCategory(string category)
        {
            return _repo.GetMentorsByCategory(category);
        }
    }
}
