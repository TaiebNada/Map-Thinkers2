using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService.M
{
  public  interface IServiceJobRequest : IService<JobRequest>
    {
         JobRequest getApplication(int idRessource);
         bool deleteApplication(int idApplication);
         bool setStateApplication(JobRequest application);
         IEnumerable<JobRequest> getAllApplication();
         IEnumerable<JobRequest> getApplicationByState(State state);
         bool assignRessource(int idr, int idp);
        IEnumerable<JobRequest> getJobRequestId(int idressource);
         int addJobRequest(JobRequest a, int idJob, int idRess);


       

    }
}
