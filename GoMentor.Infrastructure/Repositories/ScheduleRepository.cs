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
                     
            if(sch.FirstOrDefault() != null)
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
            if(schedule != null)
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
       
        public ScheduleModel[] MentorSchedules(int userId)
        {
            //Get all schedules based on mentor's mentees
            var query = from m in _context.Mentors
                        from mentee in m.Mentees
                        from sch in mentee.Schedules
                        where mentee.Mentor.UserId == userId
                        group sch by mentee;
            return null;     
        }

       
    }
}
