using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService.M
{
   public interface IServiceFolder : IService<Question>
    {
        StateMinister getStateMinister(int idApplication);
        bool setStateMinister(int idApplication, StateMinister stateM);
        StateFolder getStateFolder(int idApplication);
        bool setStateFolder(int idApplication, StateFolder stateF);
        Folder getFolder(int idApplication);
        IEnumerable<Folder> getAllFolder();
        bool sendEmail(int idr);



    }
}
