using System.Collections.Generic;
using QA.Base.Handlers;

namespace QA.Base.Interface
{
    public interface IInputParser
    {
        IParagraph ParagraphObject { get; set; }
        List<IQuestion> QuestionList { get; set; }
        List<IAnswer> PossibleAnswerList { get; set; }
        List<IAnswer> AnswerList { get; set; }
        InputRule Rule { get; }
        void Load(string input);
        void Parse();
    }
}
