using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace GoMentor.Web.Models
{
    public class ScheduleViewModel
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Details { get; set; }
        public MenteeModel Mentee { get; set; } = new MenteeModel();
        public IEnumerable<MenteeModel> Mentees { get; set; } = new HashSet<MenteeModel>();
        
        
    }
}