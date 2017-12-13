using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoMentor.Infrastructure.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Mentor> Mentors { get; set; } = new HashSet<Mentor>();
    }
}