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
  public  class ServiceQuestion :  Service<Question>, IServiceQuestion
    {

        static IDatabaseFactory dbf = new DatabaseFactory();

        //IRepositoryBase<Product> Repo = new RepositoryBase<Product>(dbf);

        //Unit Of work design pattern
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceQuestion() : base(uow)
        {

        }

        public int addQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public bool assignQuestionTest(int idQuestion, int idTest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> getAllQuestion()
        {
            throw new NotImplementedException();
        }

        public Question getQuestion(int idQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
