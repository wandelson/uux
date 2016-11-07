using System;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;

namespace RSSMostRelevantTerms
{
    public class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("We would like to analyze the most relevant terms of the website ARS Technica. "+
                "To do so please write a code that loads the most recent articles from ARS Technica’s RSS feed and returns the top 5 most frequent words "+
                "and its frequency by article. We are interested only on relevant terms so you should ignore articles, prepositions and other irrelevant words" + Environment.NewLine);

            using (var reader = XmlReader.Create(ConfigurationManager.AppSettings["URL"]))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                foreach (var feedItem in feed.Items)
                {
                    Console.WriteLine("Article : " + feedItem.Title.Text  + Environment.NewLine);
                    Console.WriteLine("List of the top 5 most frequent words by article." + Environment.NewLine);
                    foreach (SyndicationElementExtension extension in feedItem.ElementExtensions)
                    {
                        XElement text = extension.GetObject<XElement>();
                        if (text.Name.LocalName == "encoded" && text.Name.Namespace.ToString().Contains("content"))
                        {
                            var frequencyList = text.Value.Process(blackListWords: BlackList.Words.ToList()).OrderByDescending().TakeTop(5);

                            foreach (var item in frequencyList) Console.WriteLine(String.Format("{0}, {1}", item.Key, item.Value));
                        }
                    }

                    Console.WriteLine("--------------------------------------------------------------------------------------------" +Environment.NewLine);
                }
            }

            Console.ReadLine();
        }
    }
}