using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RSSMostRelevantTerms
{
    public static class ListWordsHelperExtension
    {
        public static List<KeyValuePair<String, Int32>> OrderByDescending(this List<KeyValuePair<String, Int32>> list, bool isBasedOnFrequency = true)
        {
            List<KeyValuePair<String, Int32>> result = null;
            if (isBasedOnFrequency)
                result = list.OrderByDescending(q => q.Value).ToList();
            else
                result = list.OrderByDescending(q => q.Key).ToList();
            return result;
        }

        public static List<KeyValuePair<String, Int32>> TakeTop(this List<KeyValuePair<String, Int32>> list, Int32 n = 5)
        {
            List<KeyValuePair<String, Int32>> result = list.Take(n).ToList();
            return result;
        }

        public static List<String> GetWords(this List<KeyValuePair<String, Int32>> list)
        {
            List<String> result = new List<String>();
            foreach (var item in list)
            {
                result.Add(item.Key);
            }
            return result;
        }

        public static List<Int32> GetFrequency(this List<KeyValuePair<String, Int32>> list)
        {
            List<Int32> result = new List<Int32>();
            foreach (var item in list)
            {
                result.Add(item.Value);
            }
            return result;
        }

        public static String AsString<T>(this List<T> list, string seprator = ", ")
        {
            String result = string.Empty;
            foreach (var item in list)
            {
                result += string.Format("{0}{1}", item, seprator);
            }
            return result;
        }

        public static bool IsMemberOfBlackListWords(this String word, List<String> blackListWords)
        {
            bool result = false;
            if (blackListWords == null) return false;
            foreach (var w in blackListWords)
            {
                if (w.ToNormalString().Equals(word))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static string ToCleanHtml(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public static string ToNormalString(this string input)
        {
            if (String.IsNullOrEmpty(input)) return String.Empty;
            char chNormalKaf = (char)1603;
            char chNormalYah = (char)1610;
            char chNonNormalKaf = (char)1705;
            char chNonNormalYah = (char)1740;
            string result = input.Replace(chNonNormalKaf, chNormalKaf);
            result = result.Replace(chNonNormalYah, chNormalYah);
            return result;
        }

        public static string ToCleanWord(this string text)
        {
            var normalWord = text.Replace(".", "").Replace("(", "").Replace(")", "")
                       .Replace("?", "").Replace("!", "").Replace(",", "")
                       .Replace("<br>", "").Replace(":", "").Replace(";", "")
                       .Replace("،", "").Replace("-", "").Replace("\n", "").Trim();

            return normalWord;
        }
    }
}