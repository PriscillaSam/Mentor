using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public string PostMessage { get; set; }
        public DateTime TimeOfPost { get; set; }
        public ForumModel Forum { get; set; }
        public ICollection<ReplyModel> Replies { get; set; }
    }
}
