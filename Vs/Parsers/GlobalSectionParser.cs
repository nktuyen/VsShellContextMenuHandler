using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Vs
{
    public class GlobalSectionParser : Parser
    {
        public Project Project { get { return base.Model as Project; } }
        internal GlobalSectionParser(SolutionFile solutionFile, Global global) : base(solutionFile, global)
        {

        }
        protected override ParseResult OnParse(string content)
        {
            Regex regex = new Regex("^GlobalSection([(]{1})([a-zA-Z]{1,255})([)]{1})(\\s*)([=]{1})(\\s*)([a-zA-Z]{1,255})");
            if (regex.IsMatch(content))
            {
                
            }
            else if(content== "EndGlobalSection")
            {

            }

            return base.OnParse(content);
        }
    }
}
