﻿using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Interfaces.Repositories
{
    public interface IMenteeRepository
    {
        MenteeModel AddMentee(MenteeModel model); 
    }
}