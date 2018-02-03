using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Models;
using GoMentor.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private DataEntities _context;

        public ScheduleRepository(DataEntities context)
        {
            _context = context;
        }
        public void AddSchedule(ScheduleModel model, int userId)
        {
            var date = model.Date.ToShortDateString();
            var mentee = _context.Mentees.Find(userId);

            //TODO:
            //Check if Schedule already exists
            var sch = from s in _context.Schedules
                      where s.Date == date
                      where s.MenteeId == userId
                      select s;

            if (sch.FirstOrDefault() != null)
            {
                throw new Exception("This schedule already exists");

            }
            //If it doesnt add schedule
            //Get Mentee 
            if (mentee == null)
            {
                throw new Exception("This Mentee was not found");
            }
            var time = model.Time.ToShortTimeString();
            var schedule = new Schedule
            {
                Date = date,
                Time = time,
                DateCreated = DateTime.Now,
                Details = model.Details,
                Mentee = mentee
            };

            _context.Schedules.Add(schedule);
            _context.SaveChanges();
            model.ScheduleId = schedule.ScheduleId;
        }

        public int DeleteSchedule(int scheduleId)
        {

            var schedule = _context.Schedules.Find(scheduleId);
            if (schedule != null)
            {
                _context.Entry(schedule).State = System.Data.Entity.EntityState.Deleted;
                return _context.SaveChanges();
            }

            return 0;

        }

        public ScheduleModel[] GetSchedules(int userId)
        {
            //Get Schedules based on userId
            var query = from schedule in _context.Schedules
                        where schedule.MenteeId == userId
                        select schedule;


            var record = query.ToArray();
            var schedules = from r in record
                            select new ScheduleModel
                            {
                                ScheduleId = r.ScheduleId,
                                Date = DateTime.Parse(r.Date),
                                Time = DateTime.Parse(r.Time),
                                Details = r.Details,
                                DateCreated = r.DateCreated
                            };

            return schedules.ToArray();
        }

        public MenteeModel[] MentorSchedules(int userId)
        {
            //Get all schedules based on mentor's mentees
            var query = from mentee in _context.Mentees
                        where mentee.Mentor.UserId == userId
                        where mentee.Schedules.Count != 0
                        select new
                        {
                            mentee,
                            mentee.Schedules
                        };

            var records = query.ToArray();


            var elements = from record in records
                           let schedules = from s in record.Schedules
                                           where DateTime.Parse(s.Date) > DateTime.Now
                                           select new ScheduleModel
                                           {
                                               ScheduleId = s.ScheduleId,
                                               Date = DateTime.Parse(s.Date),
                                               DateCreated = s.DateCreated,
                                               Time = DateTime.Parse(s.Time),
                                               Details = s.Details
                                           }
                           select new MenteeModel
                           {
                               User = new UserModel
                               {
                                   UserId = record.mentee.UserId,
                                   FirstName = record.mentee.User.FirstName,
                                   LastName = record.mentee.User.LastName
                               },

                               Schedules = schedules.ToArray()
                           };


            return elements.ToArray();

        }


    }
}
