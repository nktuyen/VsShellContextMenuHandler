using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ProjectSectionParser : Parser
    {
        internal ProjectSectionParser(SolutionFile solutionFile): base(solutionFile)
        {

        }

        protected override ParseResult OnParse(string lineData)
        {
            return base.OnParse(lineData);
        }
    }
}
