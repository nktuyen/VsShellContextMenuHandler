using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ProjectDependenciesParser : Parser
    {
        public ProjectDependencies ProjectDependencies { get { return base.Model as ProjectDependencies; } }
        internal ProjectDependenciesParser(SolutionFile solutionFile, ProjectDependencies dependencies): base(solutionFile, dependencies)
        {

        }
        protected override ParseResult OnParse(string lineData)
        {
            return base.OnParse(lineData);
        }
    }
}
