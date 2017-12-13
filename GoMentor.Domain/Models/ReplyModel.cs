using System;

namespace GoMentor.Domain.Models
{
    public class ReplyModel : ValidatorModel
    {
        public int ReplyId { get; set; }
        public UserModel User { get; set; }
        public string ReplyMessage { get; set; }
        public DateTime TimeOfReply { get; set; }

    }
}