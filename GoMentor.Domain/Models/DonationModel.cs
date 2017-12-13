using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Models
{
    public class DonationModel
    {
        public int DonationId { get; set; }
        public string NameOfDonor { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
    }
}
