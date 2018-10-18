using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public abstract class ConfigurationPlatforms : Model
    {
        internal ConfigurationPlatforms(ModelTypes modelTypes, string name = "", Project section = null): base(modelTypes, name, section)
        {

        }
    }
}
