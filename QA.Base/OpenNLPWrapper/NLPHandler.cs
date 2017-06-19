using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenNLP.Tools.PosTagger;
using OpenNLP.Tools.SentenceDetect;
using OpenNLP.Tools.Tokenize;
using QA.Base.Handlers;
using System.IO.Compression;

namespace QA.Base.OpenNLPWrapper
{
    public static class NLPHandler
    {
        public static string[] Sentences(this string str)
        {
            var sentenceDetector = new EnglishMaximumEntropySentenceDetector(PathFinder("EnglishSD.nbin"));
            return sentenceDetector.SentenceDetect(str);
        }

        public static string[] Words(this string str)
        {
            var tokenizer = new EnglishRuleBasedTokenizer(false);
            return tokenizer.Tokenize(str);
        }

        public static string[] Words(this string[] strArray)
        {
            var tokenizer = new EnglishRuleBasedTokenizer(false);
            var arr = new List<string>();
            strArray.ForEach(str => arr.AddRange(tokenizer.Tokenize(str)));
            return arr.ToArray();
        }

        public static string PathFinder(string str)
        {
            string basePath = @"Resources\";
            return Directory.GetFiles(basePath, "*.*", SearchOption.AllDirectories).FirstOrDefault(c => new FileInfo(c).Name == str);
        }

        public static string Tag(this string str)
        {
            var posTagger = new EnglishMaximumEntropyPosTagger(PathFinder("EnglishPOS.nbin"), PathFinder("tagdict"));
            string[] tokens = { str };
            var pos = posTagger.Tag(tokens);
            return pos.First();
        }

        public static void SetupResources()
        {
            string basePath = @"Resources\";
            string zipFilePath = "Resources.zip";
            string PathToExtract = @".\";
            if (Directory.Exists(basePath)) Directory.Delete(basePath, true);
            ZipFile.ExtractToDirectory(zipFilePath, PathToExtract);
        }
    }
}
