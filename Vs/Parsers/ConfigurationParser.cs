using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ConfigurationParser : Parser
    {
        public Configuration Configuration { get { return base.Model as Configuration; } }
        internal ConfigurationParser(SolutionFile solutionFile, Configuration config): base(solutionFile, config)
        {

        }
        protected override ParseResult OnParse(string content)
        {
            return base.OnParse(content);
        }
    }
}
