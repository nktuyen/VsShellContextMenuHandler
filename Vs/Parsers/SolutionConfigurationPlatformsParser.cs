using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class SolutionConfigurationPlatformsParser: Parser
    {
        public SolutionConfigurationPlatforms SolutionConfigurationPlatforms { get { return base.Model as SolutionConfigurationPlatforms; } }
        internal SolutionConfigurationPlatformsParser(SolutionFile solutionFile, SolutionConfigurationPlatforms slnconfigPlatforms) : base(solutionFile, slnconfigPlatforms)
        {

        }
        protected override ParseResult OnParse(string lineData)
        {
            return base.OnParse(lineData);
        }
    }
}
