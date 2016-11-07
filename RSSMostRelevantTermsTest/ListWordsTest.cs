using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSSMostRelevantTerms;
using System.Linq;

namespace RSSMostRelevantTermsTest
{
    [TestClass]
    public class ListWordsTest
    {
        [TestMethod]
        public void ShouldTopFiveWordsArticle()
        {
            string text = MockTest.Text;

            var dict = text.Process(blackListWords: BlackList.Words.ToList()).OrderByDescending().TakeTop(5);

            Assert.AreNotEqual(null, dict);
            Assert.AreEqual(5, dict.Count);
        }
    }
}