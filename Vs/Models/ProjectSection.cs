using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ProjectSection : Model
    {
        internal ProjectSection(string name = ""):base(ModelTypes.ProjectSection, name)
        {

        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
