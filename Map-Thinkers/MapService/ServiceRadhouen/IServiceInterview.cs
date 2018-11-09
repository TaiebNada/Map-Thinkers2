using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService.M
{
   public interface IServiceInterview: IService<Interview>
    {
         bool addInterview(Interview interview, int idapplication);

         bool setStateInterview(int idInterview, StateInterview state);

         Interview getInterview(int IdInterview);

         bool updateDateInterview(Interview interview);


    }
}
