using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA.Base.Interface;

namespace QA.Base.Implements
{
    public class QAParser : IQAParser
    {
        public IAnswer Process(IParagraph paragraphObject, IQuestion question, List<IAnswer> possibleAnswerList, List<IAnswer> answerList)
        {
            //the ranking gets the unique/min occuring string from the objects
            //so the ideal idea is to trace the min string of question against 3 min string of paragraph 
            //only when we are moving to grammer based, this algorithm can be changed.
            var pivots = question.PivotWord(2);
            IAnswer answer = null;
            foreach (var pivotFromQuestion in pivots)
            {
                var sentences = paragraphObject.Sentences.Where(c => c.Words.Any(w => w.SubjectInsensitive == pivotFromQuestion.SubjectInsensitive));
                //comparing with answer list is not that great, the code should be more self intelligent to provide answers.
                answer = possibleAnswerList.FirstOrDefault(c => sentences.Any(d => d.SubjectInsensitive.Contains(c.SubjectInsensitive)));
                if (answer != null && answerList.Any(c => c.Subject == answer.Subject) == false)
                {
                    answer.Index = question.Index;
                    break;
                }
                else
                {
                    //todo 
                    //need to repeat
                }
            }

            return answer;
        }
    }
}
