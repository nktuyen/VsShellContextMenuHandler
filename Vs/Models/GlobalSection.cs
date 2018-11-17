using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class GlobalSection : Model
    {
        public Global Global { get { return Parent as Global; } }
        internal GlobalSection(string name = "", Global global = null) : base(ModelTypes.GlobalSection, name, global)
        {
        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
