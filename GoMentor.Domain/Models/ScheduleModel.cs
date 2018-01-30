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
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public DateTime DateCreated { get; set; }
        public string Details { get; set; }
        public MenteeModel Mentee { get; set; }


        public override void Validate()
        {
            //Check the date supplied to ensure its in the future 
            if(Date < DateTime.Now)
            {
                throw new Exception("The selected date is passed");
            }

        }
    }

    
}
