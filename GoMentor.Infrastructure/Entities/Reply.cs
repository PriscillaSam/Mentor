using System;
using System.ComponentModel.DataAnnotations;

namespace GoMentor.Infrastructure.Entities
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    
}
}