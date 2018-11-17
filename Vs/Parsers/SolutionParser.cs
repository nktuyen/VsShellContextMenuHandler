using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Vs
{
    public class SolutionParser : Parser
    {
        private Solution Solution { get { return (Solution)base.Model; } }
        internal SolutionParser(SolutionFile solutionFile, Solution solution) : base(solutionFile, solution)
        {
            
        }

        protected override ParseResult OnParse(string content)
        {
            //Project("{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}") = "AcUi", "AcUi.vcxproj", "{1CCBB729-8536-4CD5-BC73-A487BD6F3454}"
            Regex regex = new Regex("^Project(\\s*)([(]{1})(\\s*)([\"]{1})(\\s*)([{]{1})([0-9a-zA-Z]{8})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{12})([}]{1})(\\s*)([\"]{1})([)]{1})(\\s*)([=]{1})(\\s*)([\"]{1})([0-9a-zA-Z_]{1,255})([\"]{1})(\\s*)([,]{1})(\\s*)([\"]{1})([0-9a-zA-Z_\\]{1,255})([\"]{1})(\\s*)");
            if (regex.IsMatch(content))
            {
                ParseResult parseResult = new ParseResult();
                Project prj = new Project(string.Empty, this.Solution);
                this.Solution.Projects.Add(prj);
                parseResult.Model = prj;
                return parseResult;
            }

            else if(string.Compare(content, "Global") == 0)
            {
                ParseResult parseResult = base.OnParse(content);
                Global global = new Global(string.Empty, this.Solution);
                parseResult.Model = global;
                return parseResult;
            }

            return base.OnParse(content);
        }
    }
}
