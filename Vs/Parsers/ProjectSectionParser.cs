using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ProjectSectionParser : Parser
    {
        public ProjectSection ProjectSection { get { return base.Model as ProjectSection; } }
        internal ProjectSectionParser(SolutionFile solutionFile, ProjectSection projectSection): base(solutionFile, projectSection)
        {

        }

        protected override ParseResult OnParse(string content)
        {
            return base.OnParse(content);
        }
    }
}
