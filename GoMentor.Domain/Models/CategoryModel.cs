using System.Collections.Generic;

namespace GoMentor.Domain.Models
{
    public class CategoryModel : ValidatorModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<MentorModel> Mentors { get; set; }
    }
}