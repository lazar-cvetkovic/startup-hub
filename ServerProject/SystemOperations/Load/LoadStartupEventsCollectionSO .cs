using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class LoadStartupEventQuestionsSO : SystemOperationBase
    {
        public List<RegisteredQuestion> Result { get; private set; }
        private Dictionary<string, int> _eventQuestionsId;

        public LoadStartupEventQuestionsSO(Dictionary<string, int> eventQuestionsId)
        {
            _eventQuestionsId = eventQuestionsId;
        }

        protected override void ExecuteConcreteOperation()
        {
            var prototype = new RegisteredQuestion();
            var entities = _broker.LoadRegisteredQuestions(prototype, _eventQuestionsId);

            Result = entities.OfType<RegisteredQuestion>().ToList();
        }
    }
}
