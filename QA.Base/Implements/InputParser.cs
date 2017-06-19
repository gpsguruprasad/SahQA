using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using QA.Base.Handlers;
using QA.Base.Interface;

namespace QA.Base.Implements
{
    public class InputParser : IInputParser
    {
        public InputParser(IParagraph iParagraph, IQAParser iQAParser)
        {
            ParagraphObject = iParagraph;
            QAParserObject = iQAParser;
            QuestionList = new List<IQuestion>();
            PossibleAnswerList = new List<IAnswer>();
            AnswerList = new List<IAnswer>();
        }

        public IParagraph ParagraphObject { get; set; }
        private IQAParser QAParserObject { get; set; }
        public List<IQuestion> QuestionList { get; set; }
        public List<IAnswer> PossibleAnswerList { get; set; }
        public List<IAnswer> AnswerList { get; set; }

        public InputRule Rule => JsonConvert.DeserializeObject<InputRule>(File.ReadAllText(@"InputRule.json"));

        public void Load(string input)
        {
            var inputList = input.Split(Environment.NewLine).ToList();
            ParagraphObject.Load(0, inputList[Rule.Paragraph], null);
            inputList[Rule.PossibleAnswer].SplitWithIndex(';').Create((iAnswer, index, possibleAnswer) => iAnswer.Load(index, possibleAnswer, null), PossibleAnswerList);
            inputList.GetRange(Rule.QStart, Rule.QCount).Create((iQuestion, index, question) => iQuestion.Load(index, question, ParagraphObject), QuestionList);
        }

        public void Parse()
        {
            foreach (var question in QuestionList)
            {
                IAnswer answer = QAParserObject.Process(ParagraphObject, question, PossibleAnswerList, AnswerList);
                AnswerList.Add(answer);
            }
        }
    }
}
