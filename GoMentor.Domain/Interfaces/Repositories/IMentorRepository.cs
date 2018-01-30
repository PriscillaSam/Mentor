using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Interfaces.Repositories
{
    public interface IMentorRepository
    {
        void AddMentor(MentorModel model);
        MentorModel EditMentor(MentorModel model,int userId);
        MentorModel GetMentor(int id);
        UserModel[] GetMentors();
        MentorModel[] GetMentorsByCategory(string category);
    }
}
