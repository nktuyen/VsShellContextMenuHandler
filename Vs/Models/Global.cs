using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class Global : Model
    {
        internal Global(string name="") : base(ModelTypes.Global, name)
        {

        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
