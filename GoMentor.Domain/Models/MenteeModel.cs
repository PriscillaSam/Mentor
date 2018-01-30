using System;
using System.Collections.Generic;

namespace GoMentor.Domain.Models
{
    public class MenteeModel : ValidatorModel
    {
        public int UserId { get; set; }        
        public string MobileNo { get; set; }        
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Bio { get; set; }
        public string Category { get; set; }
        public MentorModel Mentor { get; set; }
        public UserModel User { get; set; }
        public ICollection<ScheduleModel> Schedules { get; set; } = new HashSet<ScheduleModel>();

    }
}