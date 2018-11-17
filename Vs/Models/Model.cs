using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class Model
    {
        public PropertyCollection Properties { get; private set; }
        public string Name { get; internal set; }
        public Model Parent { get; protected set; }
        public ModelKind Kind { get; internal set; }
        public bool Valid { get; internal set; }
        internal bool Completed { get; set; }
        public Model(ModelTypes kind, string name = "", Model parent = null)
        {
            this.Kind = new ModelKind(kind);
            this.Name = name;
            
            this.Parent = parent;
            this.Completed = false;
            Properties = new PropertyCollection();
            Properties.Add(new Property(Vs.Properties.NAME));
            Properties.Add(new Property(Vs.Properties.KIND));
        }

        protected internal virtual bool Validate() { if (!Completed) return false; return true; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
