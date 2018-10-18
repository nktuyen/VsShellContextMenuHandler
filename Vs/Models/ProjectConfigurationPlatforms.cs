using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ProjectConfigurationPlatforms: ConfigurationPlatforms
    {
        internal ProjectConfigurationPlatforms(string name = "", Project Project = null): base(ModelTypes.ProjectConfigurationPlatforms, name, Project)
        {

        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
