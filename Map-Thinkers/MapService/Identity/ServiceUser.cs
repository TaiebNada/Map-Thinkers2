using Data.Infrastructure;
using MapData;
using MapDomain.Entities;
using MapWeb;
using MyFinance.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService.Identity
{
   public  class ServiceUser : Service<User>, ServiceUser
    {
        public ApplicationUserManager UserManager { get; set; }

        static DatabaseFactory DBF = new DatabaseFactory();
        static IUnitOfWork uow = new UnitOfWork(DBF);
        public ServiceUser() : base(uow)
        {
            ApplicationUserStore store = new ApplicationUserStore(new MapContext());
            UserManager = new ApplicationUserManager(store);

        }
    }
}
