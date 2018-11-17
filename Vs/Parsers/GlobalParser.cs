using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Vs
{
    public class GlobalParser : Parser
    {
        public Global Global { get { return base.Model as Global; } }
        internal GlobalParser(SolutionFile solutionFile, Global global) : base(solutionFile, global)
        {

        }
        protected override ParseResult OnParse(string content)
        {
            Regex regex = new Regex("^GlobalSection([(]{1})([a-zA-Z]{1,255})([)]{1})(\\s*)([=]{1})(\\s*)([a-zA-Z]{1,255})");
            if (regex.IsMatch(content))
            {
                ParseResult parseResult = new ParseResult();
                GlobalSection globalSection = new GlobalSection(string.Empty, this.Global);
                parseResult.Model = globalSection;
                return parseResult;
            }

            else if(content == "EndGlobal")
            {
                this.Model.Completed = true;
                this.Model.Valid = this.Model.Validate();
            }

            return base.OnParse(content);
        }
    }
}
