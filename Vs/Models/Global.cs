using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class Global : Model
    {
        public GlobalSectionCollection Sections { get; internal set; }
        public Solution Solution { get { return Parent as Solution; } }
        internal Global(string name = "", Solution solution = null) : base(ModelTypes.Global, name, solution)
        {
            Sections = new GlobalSectionCollection();
        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
