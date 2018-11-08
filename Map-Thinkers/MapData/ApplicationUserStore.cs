using MapDomain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapData
{
   public class ApplicationUserStore : UserStore<User>
    {
        public ApplicationUserStore(MapContext ctx) : base(ctx)
        {

        }
    }
}
