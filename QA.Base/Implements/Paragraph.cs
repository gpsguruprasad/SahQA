using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using QA.Base.Handlers;
using QA.Base.Interface;
using QA.Base.OpenNLPWrapper;

namespace QA.Base.Implements
{
    public class Paragraph : WordParentBase, IParagraph
    {
        public Paragraph()
        {
            Sentences = new List<ISentence>();
        }

        public List<ISentence> Sentences { get; set; }

        public override void Load(int index, string subject, IQABase parent)
        {
            base.Load(index, subject, parent);
            Subject.Sentences().Create((iSentence, idx, sentence) => iSentence.Load(idx, sentence, this), Sentences);
            //todo dirty way : i will come back
            Subject.Sentences().Words().Create((iWord, idx, word) => iWord.Load(idx, word, this), Words);
            Words.WordCount();
        }
    }
}