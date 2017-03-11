using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Dataasp.Backend.DatasetParsing.ParsingTools
{
    public class ProgramLineDivider
    {
        public MatchCollection DivideProgramLines(string program)
        {
            var textToAnalyze = program;
            Regex regex = new Regex(@"^.*$", RegexOptions.Multiline);
            return regex.Matches(textToAnalyze);
        }
    }
}