using System.Collections.Generic;

namespace QA.Base.Interface
{
    public interface IParagraph : IQABase, IVisitorAction, IWordParent
    {
        List<ISentence> Sentences { get; set; }
    }
}
