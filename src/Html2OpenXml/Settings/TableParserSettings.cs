using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlToOpenXml.Settings
{
    /// <summary>
    /// Special settings for parsing html tables.
    /// </summary>
    public class TableParserSettings
    {
        /// <summary>
        /// In case there is a line break or an empty paragraph within a &lt;td&gt;&lt;/td&gt; tag, the generated word document will have a greater row height than the original html which can be confusing.
        /// Set this to true if you wish to remove the br or p tag in that case.
        /// </summary>
        public bool ClearEmptyTDs { get; set; }
    }
}
