using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoMentor.Infrastructure.Entities
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public DateTime DateCreated { get; set; }
        public string Details { get; set; }

        [ForeignKey("Mentee")]
        public int MenteeId { get; set; }
        public virtual Mentee Mentee { get; set; }
        
       
    }
}