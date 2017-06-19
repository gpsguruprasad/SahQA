using QA.Base.Interface;
using QA.Base.OpenNLPWrapper;

namespace QA.Base.Implements
{
    public class Word : QABase, IWord
    {
        public string Tag { get; set; }

        public override void Load(int index, string subject, IQABase parent)
        {
            base.Load(index, subject, parent);
            //Performance issue, will have to come back. Changing logic
            //Tag = SubjectInsensitive.Tag();
        }
    }
}
