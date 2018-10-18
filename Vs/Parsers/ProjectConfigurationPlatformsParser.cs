using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ProjectConfigurationPlatformsParser : Parser
    {
        public ProjectConfigurationPlatforms ProjectConfigurationPlatforms { get { return base.Model as ProjectConfigurationPlatforms; } }
        internal ProjectConfigurationPlatformsParser(SolutionFile solutionFile, ProjectConfigurationPlatforms projectConfig) : base(solutionFile, projectConfig)
        {

        }
        protected override ParseResult OnParse(string lineData)
        {
            return base.OnParse(lineData);
        }
    }
}
