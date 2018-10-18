using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public enum ModelTypes
    {
        Unknown = 0,
        Solution,
        Project,
        ProjectSection,
        Global,
        GlobalSection,
        ProjectDependencies,
        ProjectConfigurationPlatforms,
        SolutionConfigurationPlatforms,
        Configuration,
        Platform
    }

    public class Model
    {
        public string Name { get; internal set; }
        public List<Model> Children { get; protected set; }
        public Model Parent { get; protected set; }
        public ModelTypes Kind { get; protected set; }
        public bool Valid { get; internal set; }
        internal bool Completed { get; set; }
        public Model(ModelTypes kind, string name = "", Model parent = null)
        {
            this.Kind = kind;
            this.Name = name;
            this.Parent = parent;
            this.Completed = false;
            Children = new List<Model>();
        }
        protected internal virtual bool Validate() { if (!Completed) return false; return true; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
