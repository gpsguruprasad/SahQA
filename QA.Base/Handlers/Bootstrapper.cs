using System.CodeDom;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using QA.Base.Implements;
using QA.Base.Interface;
using QA.Base.OpenNLPWrapper;

namespace QA.Base.Handlers
{
    public static class Bootstrapper
    {
        public static void Boot()
        {
            UnityHandler.Instance.RegisterType<IAnswer, Answer>();
            UnityHandler.Instance.RegisterType<IBaseParser, BaseParser>();
            UnityHandler.Instance.RegisterType<IInputParser, InputParser>();
            UnityHandler.Instance.RegisterType<IParagraph, Paragraph>();
            UnityHandler.Instance.RegisterType<IQuestion, Question>();
            UnityHandler.Instance.RegisterType<ISentence, Sentence>();
            UnityHandler.Instance.RegisterType<IWord, Word>();
            UnityHandler.Instance.RegisterType<IQAParser, QAParser>();

            NLPHandler.SetupResources();
        }
    }
}