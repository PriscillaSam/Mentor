using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Interfaces.Repositories
{
    public interface IMenteeRepository
    {
        MenteeModel AddMentee(MenteeModel model, int userId);
        MenteeModel GetMentee(int userId);
        MenteeModel EditMentee(MenteeModel model, int userId);
        void AssignMentor(int userId, int mentorId);
        bool Mentored(int userId);
        MenteeModel[] NotMentored();
        ICollection<MenteeModel> GetMentees();
        ICollection<MenteeModel> GetMenteesByMentor(int userId);
    }
}
