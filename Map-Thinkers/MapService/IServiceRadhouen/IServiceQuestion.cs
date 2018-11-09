using MapDomain.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService.M
{
   public interface IServiceQuestion : IService<Question>
    {
        int addQuestion(Question question);
        Question getQuestion(int idQuestion);
        IEnumerable<Question> getAllQuestion();
        bool assignQuestionTest(int idQuestion, int idTest);


    }
}
