using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService
{
   public interface IServiceResource : IService<User>
    {
    //   IEnumerable<User> GetProjectsByRessource(User r);

    }
}
