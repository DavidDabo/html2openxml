using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlToOpenXml.Tests
{
    [TestFixture]
    public class HtmlConverterTests: HtmlConverterTestBase
    {
        
        [Test]
        public void ClearEmptyTDS_Success()
        {
            var html = ResourceHelper.GetFileContentFromResources("TableWithBRs.html");
            var newHtml = converter.ClearEmptyTDs(html);
            Assert.IsTrue(!newHtml.Contains("<br>"));
        }

        [Test]
        public void ClearEmptyTDS_WithBRClosingTags_Success()
        {
            var html = ResourceHelper.GetFileContentFromResources("TableWithBRsClosing.html");
            var newHtml = converter.ClearEmptyTDs(html);
            Assert.IsTrue(!newHtml.Contains("<br/>"));
        }

        [Test]
        public void ClearEmptyTDS_ButNotMultipleBRs_Success()
        {
            var html = ResourceHelper.GetFileContentFromResources("TableWithBRsMultiple.html");
            var newHtml = converter.ClearEmptyTDs(html);
            //Removed single <br>
            Assert.IsTrue(!newHtml.Contains("><br><td"));

            //Remain multiple <br>
            Assert.IsTrue(newHtml.Contains("<br><br>"));
        }
    }
}
