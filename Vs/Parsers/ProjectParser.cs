using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    internal class ProjectParser : Parser
    {
        public ProjectParser(SolutionFile solutionFile): base(solutionFile)
        {

        }
        protected override ParseResult OnParse(string lineData)
        {
            return base.OnParse(lineData);
        }
    }
}
