using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Models
{
    public class ScheduleModel : ValidatorModel
    {
        public int ScheduleId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string ScheduleDetails { get; set; }
        public MenteeModel MenteeId { get; set; }
    }
}
