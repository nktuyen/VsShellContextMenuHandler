﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class Configuration : Model
    {
        internal Configuration(string name = "", Model parent = null) : base(ModelTypes.Configuration, name, parent)
        {

        }
    }
}
