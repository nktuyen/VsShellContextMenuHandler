using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public enum ModelTypes
    {
        Unknown = 0,
        Solution,
        Project,
        ProjectSection,
        Global,
        GlobalSection,
        ProjectDependencies,
        ProjectConfigurationPlatforms,
        SolutionConfigurationPlatforms,
        Configuration,
        Platform,
    }

    public class ModelKind
    {
        public ModelTypes Value { get; internal set; }
        public string Name
        {
            get
            {
                switch (this.Value)
                {
                    case ModelTypes.Configuration:
                        return "Configuration";
                    case ModelTypes.Global:
                        return "Global";
                    case ModelTypes.GlobalSection:
                        return "GlobalSection";
                    case ModelTypes.Platform:
                        return "Platform";
                    case ModelTypes.Project:
                        return "Project";
                    case ModelTypes.ProjectConfigurationPlatforms:
                        return "ProjectConfigurationPlatforms";
                    case ModelTypes.ProjectDependencies:
                        return "ProjectDependencies";
                    case ModelTypes.ProjectSection:
                        return "ProjectSection";
                    case ModelTypes.Solution:
                        return "Solution";
                    case ModelTypes.SolutionConfigurationPlatforms:
                        return "SolutionConfigurationPlatforms";
                    default:
                        return string.Empty;
                }
            }
        }
        public ModelKind(ModelTypes kind)
        {
            this.Value = kind;
        }

        public ModelKind(string name)
        {
            switch (name)
            {
                case "Configuration":
                    this.Value = ModelTypes.Configuration;
                    break;
                case "Global":
                    this.Value = ModelTypes.Global;
                    break;
                case "GlobalSection":
                    this.Value = ModelTypes.GlobalSection;
                    break;
                case "Platform":
                    this.Value = ModelTypes.Platform;
                    break;
                case "Project":
                    this.Value = ModelTypes.Project;
                    break;
                case "ProjectConfigurationPlatforms":
                    this.Value = ModelTypes.ProjectConfigurationPlatforms;
                    break;
                case "ProjectDependencies":
                    this.Value = ModelTypes.ProjectDependencies;
                    break;
                case "ProjectSection":
                    this.Value = ModelTypes.ProjectSection;
                    break;
                    break;
                case "Solution":
                    this.Value = ModelTypes.Solution;
                    break;
                case "SolutionConfigurationPlatforms":
                    this.Value = ModelTypes.SolutionConfigurationPlatforms;
                    break;
                default:
                    this.Value = ModelTypes.Unknown;
                    break;
            }
        }
    }
}
