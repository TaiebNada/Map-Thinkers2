using Data.Infrastructure;
using Infrastructure;
using MapDomain.Entities;
using MapService.IServiceRadhouen;
using MyFinance.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService.ServiceRadhouen
{
   public class ServiceTestMark : Service<TestMark>, IServiceTestMark
    {



        //MyFinanceCtx ctx = new MyFinanceCtx();
        static IDatabaseFactory dbf = new DatabaseFactory();

        //IRepositoryBase<Product> Repo = new RepositoryBase<Product>(dbf);

        //Unit Of work design pattern
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceTestMark() : base(uow)
        {

        }
    }
}
