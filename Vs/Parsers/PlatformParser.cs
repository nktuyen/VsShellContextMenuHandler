using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class PlatformParser : Parser
    {
        public Platform Platform { get { return base.Model as Platform; } }
        internal PlatformParser(SolutionFile solutionFile, Platform platform) : base(solutionFile, platform)
        {

        }
        protected override ParseResult OnParse(string lineData)
        {
            return base.OnParse(lineData);
        }
    }
}
