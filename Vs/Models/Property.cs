using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class Property
    {
        public Model Parent { get; }
        public string Name { get; }
        internal object Value { get; set; }
        internal Property(string name = "", object value = null, Model parent = null)
        {
            this.Name = name;
            this.Value = value;
            this.Parent = parent;
        }
    }
}
