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
        protected override ParseResult OnParse(string content)
        {
            int nPos = content.IndexOf('=');
            if(nPos > 0)
            {
                string value = content.Substring(nPos + 1).Trim();
                string[] values = value.Split('|');
                Solution solution = this.SolutionConfigurationPlatforms.Section.Global.Solution;
                if (values.Length > 0)
                {
                    string config = values[0];
                    solution.Configurations.Add(new Configuration(config, solution));
                }

                if(values.Length > 1)
                {
                    string platform = values[1];
                    solution.Platforms.Add(new Platform(platform, solution));
                }

                this.Model.Completed = true;
                this.Model.Valid = this.Model.Validate();
            }

            return base.OnParse(content);
        }
    }
}
