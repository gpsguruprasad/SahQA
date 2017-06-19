using System.Runtime.Remoting.Messaging;
using QA.Base.Interface;

namespace QA.Base.Implements
{
    public abstract class QABase : IQABase, IVisitorAction
    {
        public int Index { get; set; }
        public int Rank { get; set; }
        public int Count { get; set; }
        public IQABase Parent { get; set; }

        private string _subject;

        public string Subject => _subject;

        public string SubjectInsensitive
        {
            get { return _subject.ToLower(); }
            set { _subject = value; }
        }

        public virtual void Load(int index, string subject, IQABase parent)
        {
            Index = index;
            SubjectInsensitive = subject;
            Parent = parent;
        }
    }
}
