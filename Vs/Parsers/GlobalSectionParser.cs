using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Vs
{
    public class GlobalSectionParser : Parser
    {
        public GlobalSection Section { get { return base.Model as GlobalSection; } }
        internal GlobalSectionParser(SolutionFile solutionFile, GlobalSection globalSection) : base(solutionFile, globalSection)
        {

        }

        private bool ValidateName(string strName)
        {
            switch (strName)
            {
                case "Performance":
                case "SolutionConfigurationPlatforms":
                case "ProjectConfigurationPlatforms":
                case "SolutionProperties":
                case "ExtensibilityGlobals":
                    return true;
                default:
                    return false;
            }
        }

        protected override ParseResult OnParse(string content)
        {
            Regex regex = new Regex("^GlobalSection([(]{1})([a-zA-Z]{1,255})([)]{1})(\\s*)([=]{1})(\\s*)([a-zA-Z]{1,255})");
            if (regex.IsMatch(content))
            {
                int nStart = content.IndexOf('(');
                if(nStart >= 0)
                {
                    int nLast = content.IndexOf(')', nStart);
                    string strKind = content.Substring(nStart + 1, nLast - nStart - 1).Trim();
                    if (strKind != string.Empty)
                    {
                        if (ValidateName(strKind))
                        {
                            this.Section.Name = strKind;
                        }
                    }
                }
            }
            else if(content == "EndGlobalSection")
            {
                this.Model.Completed = true;
                this.Model.Valid = this.Model.Validate();
            }
            else
            {
                ModelKind modelKind = new ModelKind(this.Section.Name);
                switch (modelKind.Value)
                {
                    case ModelTypes.ProjectConfigurationPlatforms:
                        {
                            ParseResult parseResult = new ParseResult();
                            parseResult.Model = new ProjectConfigurationPlatforms(string.Empty, this.Section);
                            return parseResult;
                        }
                    case ModelTypes.SolutionConfigurationPlatforms:
                        {
                            ParseResult parseResult = new ParseResult();
                            parseResult.Model = new SolutionConfigurationPlatforms(string.Empty, this.Section);
                            return parseResult;
                        }
                    default: break;
                }
            }

            return base.OnParse(content);
        }
    }
}
