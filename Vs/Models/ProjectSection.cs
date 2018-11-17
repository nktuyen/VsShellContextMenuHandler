using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ProjectSection : Model
    {
        internal ProjectSection(string name = "", Project project = null):base(ModelTypes.ProjectSection, name, project)
        {

        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
