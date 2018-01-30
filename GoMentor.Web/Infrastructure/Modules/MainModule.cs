using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Interfaces.Utilities;
using GoMentor.Infrastructure.Entities;
using GoMentor.Infrastructure.Repositories;
using GoMentor.Infrastructure.Utilities;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoMentor.Web.Infrastructure.Modules
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<DataEntities>();
            Bind<IEncryption>().To<MD5Encryption>();
            Bind<IMenteeRepository>().To<MenteeRepository>();
            Bind<IMentorRepository>().To<MentorRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IScheduleRepository>().To<ScheduleRepository>();
            
        }
    }
}