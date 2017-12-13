using System;
using System.ComponentModel.DataAnnotations;

namespace GoMentor.Infrastructure.Entities
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public DateTime DateCreated { get; set; }
        public string MeetingDetails { get; set; }
        public int MenteeId { get; set; }
        public virtual Mentee Mentee { get; set; }
    }
}