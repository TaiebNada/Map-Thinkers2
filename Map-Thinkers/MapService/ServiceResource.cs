using Data.Infrastructure;
using Infrastructure;
using MapDomain.Entities;
using MyFinance.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService
{
    public class ServiceResource : Service<User>, IServiceResource
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

      
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceResource() : base(uow)
        {

        }

      /* public IEnumerable<User> GetProjectsByRessource(User r)
        {
            throw new NotImplementedException();
        }
        */
    }
}
