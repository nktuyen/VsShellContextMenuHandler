using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Vs
{
    public class ProjectConfigurationPlatformsParser : Parser
    {
        public ProjectConfigurationPlatforms ProjectConfigurationPlatforms { get { return base.Model as ProjectConfigurationPlatforms; } }
        internal ProjectConfigurationPlatformsParser(SolutionFile solutionFile, ProjectConfigurationPlatforms projectConfig) : base(solutionFile, projectConfig)
        {

        }
        protected override ParseResult OnParse(string content)
        {
            int nPos = content.IndexOf('=');
            if (nPos > 0)
            {
                string name = content.Substring(0, nPos).Trim();
                string[] names = name.Split('.');
                Solution solution = this.ProjectConfigurationPlatforms.Section.Global.Solution;
                Project project = null;
                if (names.Length > 0)
                {
                    string guid = names[0];
                    Regex regex = new Regex("([{]{1})([0-9a-zA-Z]{8})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{12})([}]{1})");
                    if (regex.IsMatch(guid))
                    {
                        if (guid[0] == '{')
                            guid = guid.Remove(0, 1);
                        if (guid[guid.Length - 1] == '}')
                            guid = guid.Remove(guid.Length - 1);

                        project = solution.Projects.FindProject(guid);
                    }
                }

                string value = content.Substring(nPos + 1).Trim();
                string[] values = value.Split('|');

                if (project != null)
                {

                    if (values.Length > 0)
                    {
                        string config = values[0];
                        project.Configurations.Add(new Configuration(config, solution));
                    }

                    if (values.Length > 1)
                    {
                        string platform = values[1];
                        project.Platforms.Add(new Platform(platform, solution));
                    }
                }

                this.Model.Completed = true;
                this.Model.Valid = this.Model.Validate();
            }

            return base.OnParse(content);
        }
    }
}
