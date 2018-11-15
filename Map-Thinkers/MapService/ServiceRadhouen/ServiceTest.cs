using Data.Infrastructure;
using Infrastructure;
using MapDomain.Entities;
using MapService.M;
using MyFinance.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService.ServiceRadhouen
{
 public   class ServiceTest : Service<Test>, IServiceTest
    {


        //MyFinanceCtx ctx = new MyFinanceCtx();
        static IDatabaseFactory dbf = new DatabaseFactory();

        //IRepositoryBase<Product> Repo = new RepositoryBase<Product>(dbf);

        //Unit Of work design pattern
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceTest() : base(uow)
        {

        }

        public int addTest(Test t)
        {
            throw new NotImplementedException();
        }

        public bool assignTest(int idTest, int idApp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Test> getAllTest()
        {
            throw new NotImplementedException();
        }

        public float getResultTest(int idTest, int idApp)
        {
            throw new NotImplementedException();
        }

        public Test getTest(int idTest, int idApp)
        {
            throw new NotImplementedException();
        }

        public int passeTest(int a, int t, int note)
        {
            throw new NotImplementedException();
        }
    }
}
