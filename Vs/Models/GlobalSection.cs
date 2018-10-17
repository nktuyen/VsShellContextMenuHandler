using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class GlobalSection : Model
    {
        internal GlobalSection(string name = "") : base(ModelTypes.GlobalSection, name)
        {

        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
