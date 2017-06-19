using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Base.Interface
{
    public interface IQAParser
    {
        IAnswer Process(IParagraph paragraphObject, IQuestion question, List<IAnswer> possibleAnswerList, List<IAnswer> answerList);
    }
}
