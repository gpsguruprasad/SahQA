using QA.Base.Handlers;
using QA.Base.Interface;

namespace QA.Base.Implements
{
    public class BaseParser : IBaseParser
    {
        public BaseParser(IInputParser inputParser)
        {
            InputParserObject = inputParser;
        }

        private string InputQuestion { get; set; }
        private IInputParser InputParserObject { get; set; }

        public void Input(string input)
        {
            InputQuestion = input;
        }

        public string Process()
        {
            InputParserObject.Load(InputQuestion);
            InputParserObject.Parse();
            return InputParserObject.AnswerList.ToSubjectString();
        }
    }
}
