using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class Solution : Model
    {
        public ProjectCollection Projects { get; protected set; }
        public string Path { get; internal set; }
        public Global Global { get; internal set; }
        public Solution(string name = "") : base(ModelTypes.Solution, name)
        {
            Projects = new ProjectCollection();
        }

        internal Project AddProject(string name)
        {
            Project prj = Projects.FindProject(name);
            if (prj == null)
            {
                prj = new Project(name);
                Projects.Add(prj);
            }

            return prj;
        }

        protected internal override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (Name == null || Name == string.Empty)
                return false;

            if (Path == null || Path == string.Empty)
                return false;

            if (!Projects.Validate())
                return false;

            return true;
        }
    }
}
