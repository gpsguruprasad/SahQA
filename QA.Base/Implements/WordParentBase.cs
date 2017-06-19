using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using QA.Base.Handlers;
using QA.Base.Interface;
using QA.Base.OpenNLPWrapper;

namespace QA.Base.Implements
{
    public abstract class WordParentBase : QABase, IWordParent
    {
        protected WordParentBase()
        {
            Words = new List<IWord>();
        }

        public List<IWord> Words { get; set; }

        public void LoadWords()
        {
            Subject.Words().Create((iWord, idx, word) => iWord.Load(idx, word, this), Words);
            Words.WordCount();
        }

        public List<IWord> PivotWord(int rank)
        {
            //todo : operate on token and grammer, performance issues, have to ignore frequent words
            var wordParent = Parent as IWordParent;
            var list = wordParent.Words.Where(word => Words.Select(c => c.SubjectInsensitive).Contains(word.SubjectInsensitive));
            return list.DistinctBy(c => c.SubjectInsensitive).OrderBy(d => d.Count).Take(rank).ToList();
        }
    }
}