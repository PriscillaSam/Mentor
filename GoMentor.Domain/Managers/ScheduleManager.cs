using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Managers
{
    public class ScheduleManager
    {
        private IScheduleRepository _scheduleRepo;

        public ScheduleManager(IScheduleRepository scheduleRepo)
        {
            _scheduleRepo = scheduleRepo;
        }

        public void CreateSchedule(ScheduleModel model, int userId)
        {
            //Check the model supplied
            model.Validate();

            //Go ahead and create schedule
            _scheduleRepo.AddSchedule(model, userId);

        }

        public void DeleteSchedule(int scheduleId)
        {
            _scheduleRepo.DeleteSchedule(scheduleId);
        }

        public ScheduleModel[] GetSchedules(int userId)
        {
            return  _scheduleRepo.GetSchedules(userId);
        }

        public MenteeModel[] GetMentorSchedules(int userId)
        {
            return _scheduleRepo.MentorSchedules(userId);
        }
    }
}
