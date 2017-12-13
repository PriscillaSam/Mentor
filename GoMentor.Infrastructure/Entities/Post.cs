using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Infrastructure.Entities
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public int ForumId { get; set; }
        public int UserId { get; set; }
        public DateTime TIme { get; set; }
        public virtual User User { get; set; }
        public virtual Forum Forum { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
