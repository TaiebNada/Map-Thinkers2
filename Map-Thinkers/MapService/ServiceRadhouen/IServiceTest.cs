using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService.M
{
  public  interface IServiceTest : IService<Test>
    {
         int passeTest(int a, int t, int note);
         float getResultTest(int idTest, int idApp);
         int addTest(Test t);
         Test getTest(int idTest, int idApp);
         IEnumerable<Test> getAllTest();
        bool assignTest(int idTest, int idApp);

    }
}
