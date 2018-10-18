using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class SolutionConfigurationPlatforms : ConfigurationPlatforms
    {
        internal SolutionConfigurationPlatforms(string name = "", Project Project = null) : base (ModelTypes.SolutionConfigurationPlatforms, name, Project)
        {

        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
