using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musupr.Service.Helpers;

namespace Musupr.Tests
{
    [TestClass]
    public class TestesHtmlTagRemoval
    {
        [TestMethod]
        public void TesteHtmlRemovalStripTagsRegex()
        {
            string html = "<p>There was a <b>.NET</b> programmer and he stripped the <i>HTML</i> tags.</p>";

            Assert.AreEqual(HtmlRemoval.StripTagsRegex(html), "There was a .NET programmer and he stripped the HTML tags.");
        }

        [TestMethod]
        public void TesteHtmlRemovalStripTagsRegexCompiled()
        {
            string html = "<p>There was a <b>.NET</b> programmer and he stripped the <i>HTML</i> tags.</p>";

            Assert.AreEqual(HtmlRemoval.StripTagsRegexCompiled(html), "There was a .NET programmer and he stripped the HTML tags.");
        }

        [TestMethod]
        public void TesteHtmlRemovalStripTagsCharArray()
        {
            string html = "<p>There was a <b>.NET</b> programmer and he stripped the <i>HTML</i> tags.</p>";

            Assert.AreEqual(HtmlRemoval.StripTagsCharArray(html), "There was a .NET programmer and he stripped the HTML tags.");
        }


    }
}
