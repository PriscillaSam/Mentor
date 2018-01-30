using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoMentor.Web.Models
{
    public class AdminViewModel
    {
        public MenteeModel[] Users;
        public UserModel Admin = new UserModel();

    }
}