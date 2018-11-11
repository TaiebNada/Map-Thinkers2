using Data.Infrastructure;
using Infrastructure;
using MapDomain.Entities;
using MapService.M;
using MapService.ServiceRadhouen;
using MyFinance.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MapService.ServiceRadhouen
{
   public class ServiceJobRequest : Service<JobRequest>, IServiceJobRequest
    {

        //MyFinanceCtx ctx = new MyFinanceCtx();
        static IDatabaseFactory dbf = new DatabaseFactory();

        //IRepositoryBase<Product> Repo = new RepositoryBase<Product>(dbf);

        //Unit Of work design pattern
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceJobRequest() : base(uow)
        {

        }

        public int addJobRequest(JobRequest a, int idJob, int idRess)
        {
            throw new NotImplementedException();
        }

        public bool assignRessource(int idr, int idp)
        {
            throw new NotImplementedException();
        }

        public bool deleteApplication(int idApplication)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobRequest> getAllApplication()
        {
            throw new NotImplementedException();
        }

        public JobRequest getApplication(int idRessource)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobRequest> getApplicationByState(State state)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobRequest> getJobRequestId(int idressource)
        {
            throw new NotImplementedException();
        }

        public bool setStateApplication(JobRequest application)
        {
            throw new NotImplementedException();
        }
    }
}
