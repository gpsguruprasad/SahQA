using QA.Base.Interface;
using QA.Base.OpenNLPWrapper;

namespace QA.Base.Implements
{
    public class Word : QABase, IWord
    {
        public string Tag => this.Subject.Tag();
    }
}
