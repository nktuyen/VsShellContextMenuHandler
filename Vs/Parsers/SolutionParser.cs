using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Vs
{
    public class SolutionParser : Parser
    {
        private Solution Solution { get { return (Solution)base.Model; } set { Model = (Model)value; } }
        private Project CurrentProject { get; set; }
        internal SolutionParser(SolutionFile solutionFile) : base(solutionFile)
        {
            Solution = new Solution(File.Name);
        }

        protected override ParseResult OnParse(string content)
        {
            ParseResult parseResult = new ParseResult();
            //Project("{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}") = "AcUi", "AcUi.vcxproj", "{1CCBB729-8536-4CD5-BC73-A487BD6F3454}"
            Regex regex = new Regex("^Project(\\s*)([(]{1})(\\s*)([\"]{1})(\\s*)([{]{1})([0-9a-zA-Z]{8})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{12})([}]{1})(\\s*)([\"]{1})([)]{1})(\\s*)([=]{1})(\\s*)([\"]{1})([0-9a-zA-Z]{1,255})([\"]{1})(\\s*)([,]{1})(\\s*)([\"]{1})([0-9a-zA-Z\\]{1,255})([\"]{1})(\\s*)");
            if (regex.IsMatch(content))
            {
                this.CurrentProject = new Project();
                parseResult.Index = content.IndexOf("Project");
                parseResult.Length = "Project".Length;
                parseResult.Model = this.CurrentProject;
                return parseResult;
            }

            else if(string.Compare(content, "EndProject") == 0)
            {
                if(this.CurrentProject != null)
                {
                    this.CurrentProject.Completed = true;
                    if (this.CurrentProject.Valid)
                    {
                        this.Solution.Projects.Add(this.CurrentProject);
                    }
                    this.CurrentProject = null;
                }
                parseResult.Index = 0;
                parseResult.Length = "EndProject".Length;
                return parseResult;
            }

            return base.OnParse(content);
        }
    }
}
