using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Models;
using GoMentor.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Infrastructure.Repositories
{
    public class MenteeRepository : IMenteeRepository
    {
        private DataEntities _context;

        //public MenteeRepository(DbContext context)
        //{
        //    _context = context;
        //}

        public MenteeRepository(DataEntities context)
        {
            _context = context;
        }
        public MenteeModel AddMentee(MenteeModel model)
        {
            _context.Mentees.Add(new Mentee
            {

            });
             return null;
        }
    }
}
