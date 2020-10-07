using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlToOpenXml.Tests.Utilities
{
    public static class WordDocumentCreator
    {
        public static void Create(string filepath, string innerhtml)
        {
            using (FileStream generatedDocument = new FileStream(filepath, FileMode.CreateNew, FileAccess.ReadWrite))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
                sb.Append("<html>");
                sb.Append("<head>");
                sb.Append("<title></title>");
                sb.Append("</head>");
                sb.Append("<body>");
                var htmlDoc = new HtmlDocument();

                if (!string.IsNullOrWhiteSpace(innerhtml))
                {
                    htmlDoc.LoadHtml(innerhtml);

                    sb.Append("<div style='page-break-after:always'></div>");


                    innerhtml = innerhtml.Replace("<p><br></p>", "<p></p>");

                    sb.Append(innerhtml);
                }

                sb.Append("</body>");
                sb.Append("</html>");

                string html = sb.ToString();
                generatedDocument.Position = 0L;


                using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = package.MainDocumentPart;
                    if (mainPart == null)
                    {
                        mainPart = package.AddMainDocumentPart();
                        new Document(new Body()).Save(mainPart);
                    }

                    HtmlConverter converter = new HtmlConverter(mainPart);
                    //converter.BeforeProcess += OnBeforeProcess;
                    //converter.AfterProcess += Converter_AfterProcess;

                    converter.ParseHtml(html);
                    mainPart.Document.Save();
                    mainPart.ToString();
                }
            }
        }
    }
}
