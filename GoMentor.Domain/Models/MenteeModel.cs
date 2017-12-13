namespace GoMentor.Domain.Models
{
    public class MenteeModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int MobileNo { get; set; }
        public string ProfilePicture { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PersonalInfo { get; set; }
        public CategoryModel Category { get; set; }
        public MentorModel Mentor { get; set; }
    }
}