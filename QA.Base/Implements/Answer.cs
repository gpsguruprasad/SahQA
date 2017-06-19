using System.Collections.Generic;
using QA.Base.Handlers;
using QA.Base.Interface;
using QA.Base.OpenNLPWrapper;

namespace QA.Base.Implements
{
    public class Answer : WordParentBase, IAnswer
    {
        public override void Load(int index, string subject, IQABase parent)
        {
            base.Load(index, subject, parent);
            LoadWords();
        }
    }
}
