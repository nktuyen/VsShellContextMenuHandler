using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs.Models
{
    public class ProjectConfigurationPlatforms: Model
    {
        internal ProjectConfigurationPlatforms(string name = ""): base(ModelTypes.ProjectConfigurationPlatforms, name)
        {

        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
