using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class SolutionConfigurationPlatforms : ConfigurationPlatforms
    {
        internal SolutionConfigurationPlatforms(string name = "", GlobalSection section = null) : base (ModelTypes.SolutionConfigurationPlatforms, name, section)
        {

        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
