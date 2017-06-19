using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Base.Interface
{
    public interface IWordParent
    {
        List<IWord> Words { get; set; }
        void LoadWords();
        List<IWord> PivotWord(int rank);
    }
}
