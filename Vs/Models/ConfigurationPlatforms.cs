using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public abstract class ConfigurationPlatforms : Model
    {
        public GlobalSection Section { get { return Parent as GlobalSection; } }
        internal ConfigurationPlatforms(ModelTypes modelTypes, string name = "", GlobalSection section = null): base(modelTypes, name, section)
        {

        }
    }
}
