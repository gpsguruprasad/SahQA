using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using QA.Base.Interface;

namespace QA.Base.Handlers
{
    public static class Extension
    {
        public static string ToSubjectString(this IEnumerable<IQABase> bases) => bases.OrderBy(c => c.Index).Select(c => c.Subject).ToSubjectString();

        public static string ToSubjectString(this IEnumerable<string> stringList) => string.Join(Environment.NewLine, stringList);

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var tObj in enumerable)
            {
                action(tObj);
            }
        }

        public static Dictionary<int, string> SplitWithIndex(this string str, char splitString)
        {
            return str.Split(splitString).Select((value, index) => new { value, index }).ToDictionary(pair => pair.index, pair => pair.value);
        }

        public static void Create<TCreate, TSubject>(this IEnumerable<TSubject> list, Action<TCreate, int, TSubject> action, List<TCreate> collection)
        {
            var dict = list.Select((s, i) => new { s, i }).ToDictionary(x => x.i, x => x.s);
            dict.Create(action, collection);
        }

        public static void Create<TCreate, TSubject>(this Dictionary<int, TSubject> enumerable, Action<TCreate, int, TSubject> action, List<TCreate> collection)
        {
            foreach (var enumerator in enumerable)
            {
                var answer = UnityHandler.Instance.Resolve<TCreate>();
                action(answer, enumerator.Key, enumerator.Value);
                collection.Add(answer);
            }
        }

        public static void WordCount(this List<IWord> enumerable)
        {
            var countDict = enumerable.Select(c => c.SubjectInsensitive).GenerateCount();
            enumerable.ForEach(enumerator => enumerator.Count = countDict[enumerator.SubjectInsensitive]);
        }

        public static string[] Split(this string str, string splitString) => str.Split(new[] { splitString }, StringSplitOptions.None);

        public static Dictionary<string, int> GenerateCount(this IEnumerable<string> lists)
        {
            return lists.GroupBy(tag => tag).ToDictionary(group => group.Key, group => group.Count());
        }
    }
}
