using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class Solution : Model
    {
        public ProjectCollection Projects { get; protected set; }
        public PlatformCollection Platforms { get; private set; }
        public ConfigurationCollection Configurations { get; private set; }
        public string Directory { get; internal set; }
        public string Path { get { if(null!= Directory && string.Empty!= Directory) return Directory + "\\" + Name; return string.Empty; } }
        public Solution(string name = "", string path = "") : base(ModelTypes.Solution, name)
        {
            Projects = new ProjectCollection();
            Platforms = new PlatformCollection();
            Configurations = new ConfigurationCollection();
            Directory = string.Empty;
            Properties.Add(new Property(Vs.Properties.DIRECTORY));
            Properties.Add(new Property(Vs.Properties.PATH));
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
