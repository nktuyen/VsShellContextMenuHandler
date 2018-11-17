using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class Project : Model
    {
        public Solution Solution { get { return Parent as Solution; } }
        public PlatformCollection Platforms { get; private set; }
        public ConfigurationCollection Configurations { get; private set; }
        public string Guid { get; internal set; }
        public string Path { get; internal set; }
        public Project(string name = "", Solution solution = null) :base (ModelTypes.Project, name, solution)
        {
            Platforms = new PlatformCollection();
            Configurations = new ConfigurationCollection();
            Guid = string.Empty;
            Path = string.Empty;
            Properties.Add(new Property(Vs.Properties.PATH));
            Properties.Add(new Property(Vs.Properties.GUID));
        }

        protected internal override bool Validate()
        {
            if (!base.Validate())
                return false;

            if (Name == null || Name == string.Empty)
                return false;

            if (Path == null || Path == string.Empty)
                return false;

            if (Guid == null || Guid == string.Empty)
                return false;

            return true;
        }
    }
}
