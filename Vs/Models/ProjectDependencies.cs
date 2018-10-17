using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ProjectDependencies : Model
    {
        internal ProjectDependencies (string name = ""): base(ModelTypes.ProjectDependencies, name)
        {

        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
