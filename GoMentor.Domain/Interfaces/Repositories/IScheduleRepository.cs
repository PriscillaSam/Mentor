using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Interfaces.Repositories
{
    public interface IScheduleRepository
    {
        void AddSchedule(ScheduleModel model, int userId);
        int DeleteSchedule(int scheduleId);
        ScheduleModel[] GetSchedules(int userId);
    }
}
