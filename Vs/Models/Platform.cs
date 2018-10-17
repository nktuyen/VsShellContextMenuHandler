using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class Platform : Model
    {
        internal Platform(string name = "") : base(ModelTypes.Platform, name)
        {

        }
        protected internal override bool Validate()
        {
            return base.Validate();
        }
    }
}
