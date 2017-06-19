using System.Collections.Generic;

namespace QA.Base.Interface
{
    public interface IVisitorAction
    {
        void Load(int index, string subject, IQABase parent);
    }
}