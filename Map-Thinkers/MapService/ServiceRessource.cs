using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MapDomain.Entities;
using ServicePattern;
using Infrastructure;
using MyFinance.Data.Infrastructure;
using Data.Infrastructure;

namespace MapService
{
    public class ServiceRessource : Service<Ressource>,IServiceRessource
    {
        static IDatabaseFactory dbf = new DatabaseFactory();


        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceRessource() : base(uow)
        {

        }


    }
}
