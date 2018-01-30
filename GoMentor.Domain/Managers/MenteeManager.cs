using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Managers
{
    public class MenteeManager
    {
        private IMenteeRepository _repo;

        public MenteeManager(IMenteeRepository repo)
        {
            _repo = repo;
        }
        public MenteeModel AddMentee(MenteeModel model, int userId)
        {
            //Check if Mentee already exists
            var mentee = _repo.GetMentee(userId);
            if (mentee != null)
            {
                //If there is already a mentee
                throw new Exception("Mentee Records Already Exist");
            }
            mentee = _repo.AddMentee(model, userId);
            return mentee;
        }
        public void AssignMentor(MenteeModel model, int mentorId)
        {
            //Check if Mentee already has mentor
            var exists =_repo.Mentored(model.UserId);
            if (exists)
            {
                throw new Exception("Mentee Already Has a Mentor");
            }

            _repo.AssignMentor(model.UserId, mentorId);
        }

        public MenteeModel GetMentee(int userId)
        {
            return _repo.GetMentee(userId);
        }

        public MenteeModel EditMentee(MenteeModel model , int userId)
        {
            return _repo.EditMentee(model, userId);
        }
        public MenteeModel[] GetNotMentored()
        {
            return _repo.NotMentored();           

        }

        public IEnumerable<MenteeModel> GetMentees(int userId)
        {
            var menteeList = _repo.GetMenteesByMentor(userId);
            if(menteeList == null)
            {
                return new List<MenteeModel>();
                //throw new Exception("No Mentees yes");
            }

            return menteeList;
        }
        
    }
}
