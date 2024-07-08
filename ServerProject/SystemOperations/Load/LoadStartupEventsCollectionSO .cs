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
            string joinTable = "StartupEventRegistration";
            Dictionary<string, string> joinOn = new Dictionary<string, string>
            {
                {"EventId", "EventId"},
                {"UserId", "UserId"}
            };

            var ids = new Dictionary<string, object>(_eventQuestionsId.ToDictionary(k => k.Key, v => (object)v.Value));

            var entities = _broker.LoadByJoinCondition(prototype, ids, joinTable, joinOn);

            Result = entities.OfType<RegisteredQuestion>().ToList();
        }
    }
}
