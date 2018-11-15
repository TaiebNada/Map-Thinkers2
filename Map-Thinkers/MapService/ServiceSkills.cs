using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFinance.Data.Infrastructure;
using Data.Infrastructure;
using Infrastructure;

namespace MapService
{
   public class ServiceSkills : Service<Skills>, IServiceSkills
    {
       
        static IDatabaseFactory dbf = new DatabaseFactory();


        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceSkills() : base(uow)
        {
        }

        
    }
}
