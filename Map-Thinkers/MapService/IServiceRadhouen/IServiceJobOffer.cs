using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService.M
{
  public  interface IServiceJobOffer : IService<JobOffer>
    {
         int addJobOffer(JobOffer jobOffer);
         bool updateOffer(JobOffer jobOffer);
         bool removeJobOffer(int idJobOffer);
         JobOffer getJobOffer(int idJobOffer);
         IEnumerable<JobOffer> getAllJobOffer();
         IEnumerable<JobOffer> getJobOfferExperience(string exp);



    }
}
