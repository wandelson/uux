using System;
using System.Collections.Generic;
using System.Linq;

namespace RSSMostRelevantTerms
{
    public static class ListWordsProcessorExtension
    {
        public static List<KeyValuePair<String, int>> Process(this String bodyText,
            List<string> blackListWords = null, int minimumWordLength = 3,
            char splitor = ' ',
            bool perWordIsLowerCase = true)
        {
            bodyText = bodyText.ToCleanHtml();

            var btArray = bodyText.ToNormalString().Split(splitor);

            long numberOfWords = btArray.LongLength;

            var wordsDic = new Dictionary<string, int>(1);

            foreach (string word in btArray)
            {
                if (word != null)
                {
                    var normalWord = word.ToCleanWord().ToLower();

                    if ((normalWord.Length > minimumWordLength && !normalWord.IsMemberOfBlackListWords(blackListWords)))
                    {
                        if (wordsDic.ContainsKey(normalWord))
                        {
                            var cnt = wordsDic[normalWord];
                            wordsDic[normalWord] = ++cnt;
                        }
                        else
                        {
                            wordsDic.Add(normalWord, 1);
                        }
                    }
                }
            }
            var keywords = wordsDic.ToList();

            return keywords;
        }
    }

}