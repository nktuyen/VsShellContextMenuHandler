using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs.Models
{
    public class SolutionConfigurationPlatforms : Model
    {
        internal SolutionConfigurationPlatforms(string name = "") : base(ModelTypes.SolutionConfigurationPlatforms, name)
        {

        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
