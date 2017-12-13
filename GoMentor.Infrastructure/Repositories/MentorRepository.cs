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
    public class MentorRepository :IMentorRepository
    { 
       
            private DbContext _context;

            public MentorRepository(DbContext context)
            {
                _context = context;
            }

            public void AddMentor()
            {
                
            }

            public MentorModel[] GetMentors()
            {
            //var query = from mentor in _context.Set<Mentor>()
            //            select mentor;

            //var records = query.ToArray();

            //var mentors = from record in records
            //              select new MentorModel
            //              {
            //                  UserId = record.UserId,
            //                  FirstName = record.FirstName,
            //                  LastName = record.LastName,
            //                  ProfilePicture = record.Image
            //              };

            //return mentors.ToArray();
            return null;

            }

            //This Method uses query to get a single mentor from the database
            public MentorModel GetMentor(int id)
            {

                var query = from m in _context.Set<Mentor>()
                            select m;

                //var records = query.ToArray();
                //var query2 = from record in records
                //             where record.UserId == id
                //             let mentees = from mentee in record.Mentees
                //                           select new MenteeModel
                //                           {
                //                               UserId = mentee.UserId,
                //                               FirstName = mentee.FirstName,
                //                               LastName = mentee.LastName,
                //                               Email = mentee.Email,
                //                               ProfilePicture = mentee.Picture
                //                           }
                //             select new MentorModel
                //             {
                //                 UserId = record.UserId,
                //                 FirstName = record.FirstName,
                //                 LastName = record.LastName,
                //                 ProfilePicture = record.Image,
                //                 MobileNo = record.MobileNo,
                //                 Email = record.Email,
                //                 Mentees = mentees.ToArray()
                //             };

                var mentor = query.FirstOrDefault();
                return null;

            }
    }
}

