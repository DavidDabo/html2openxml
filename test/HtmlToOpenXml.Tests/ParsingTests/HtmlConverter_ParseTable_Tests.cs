using DocumentFormat.OpenXml.Packaging;
using HtmlToOpenXml.Tests.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlToOpenXml.Tests.ParsingTests
{
    [TestFixture]
    public class HtmlConverter_ParseTable_Tests : HtmlConverterTestBase
    {
        [TestCase]
        public void ParseTable_Success()
        {
            var html = ResourceHelper.GetFileContentFromResources("Table.html");
            var dir = @"C:\Users\DavidBolt\source\repos\html2openxml_dave\test\HtmlToOpenXml.Tests\Resources\";
            var filename = $"Table_{DateTime.Now:yyyyMMddHHmmss}.docx";
            WordDocumentCreator.Create($"{Path.Combine(dir, filename)}", html);
        }

        [TestCase]
        public void ParseTableWithBRs_Success()
        {
            var html = ResourceHelper.GetFileContentFromResources("TableWithBRs.html");
            var dir = @"C:\Users\DavidBolt\source\repos\html2openxml_dave\test\HtmlToOpenXml.Tests\Resources\";
            var filename = $"Table_{DateTime.Now:yyyyMMddHHmmss}.docx";
            WordDocumentCreator.Create($"{Path.Combine(dir, filename)}", html);
        }
    }
}
