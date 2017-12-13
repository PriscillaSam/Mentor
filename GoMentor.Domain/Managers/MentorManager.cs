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
        private IMentorRepository repo;
        public MentorModel GetMentor(int id )
        {
            return repo.GetMentor(id);
        }
    }
}
