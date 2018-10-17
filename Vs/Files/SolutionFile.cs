using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Vs
{
    public class SolutionFile : File
    {
        public Solution Solution { get; private set; }
        private Model CurrentModel { get; set; }
        private long CurrentLine { get; set; }
        private Stack<Parser> Parsers = new Stack<Parser>();
        public string FormatVersionString { get; private set; }
        public Version FormatVersion
        {
            get
            {
                string[] ver = this.FormatVersionString.Split('.');
                int major = 0;
                int minor = 0;
                if (ver.Length > 1)
                    int.TryParse(ver[0], out major);
                if (ver.Length > 2)
                    int.TryParse(ver[1], out minor);

                return new Version(major, minor);
            }
        }
        public SolutionFile(string strPath = ""): base(strPath)
        {
            this.Solution = null;
            this.FormatVersionString = string.Empty;
        }

        protected virtual Parser CreateParser(ModelTypes modelTypes)
        {
            switch (modelTypes)
            {
                case ModelTypes.Solution:
                    return new SolutionParser(this);
                case ModelTypes.SolutionConfigurationPlatforms:
                    return new SolutionConfigurationPlatformsParser(this);
                case ModelTypes.Project:
                    return new ProjectParser(this);
                case ModelTypes.ProjectSection:
                    return new ProjectSectionParser(this);
                case ModelTypes.ProjectConfigurationPlatforms:
                    return new ProjectConfigurationPlatformsParser(this);
                case ModelTypes.ProjectDependencies:
                    return new ProjectDependenciesParser(this);
                case ModelTypes.Global:
                    return new GlobalParser(this);
                case ModelTypes.GlobalSection:
                    return new GlobalSectionParser(this);
                case ModelTypes.Platform:
                    return new PlatformParser(this);
                case ModelTypes.Configuration:
                    return new ConfigurationParser(this);
                default:
                    return null;
            }
        }

        protected void OnFileLoadStart(object sender, LineReadingEventArgs e)
        {
            CurrentLine = 0;
            Parsers.Clear();
        }

        protected override void OnFileLineReading(LineReadingEventArgs e)
        {
            base.OnFileLineReading(e);
            if (e.Data != null)
            {
                string strLine = e.Data.Trim();

                bool bDiff = (e.Data.Length != strLine.Length);
                if(bDiff)
                    Debug.Print(string.Format("{0,3}: \"{1}\"[{2}] ||| \"{3}\"[{4}] ***DIFF***", e.Line, e.Data, e.Data.Length, strLine, strLine.Length));
                else
                    Debug.Print(string.Format("{0,3}: \"{1}\"[{2}] ||| \"{3}\"[{4}]",e.Line, e.Data, e.Data.Length, strLine, strLine.Length));

                if (strLine == string.Empty || strLine.Length <= 0)
                    return;

                CurrentLine++;

                if (strLine.Length > 0)
                {
                    if (strLine.Substring(0, 1).CompareTo("#") == 0)
                        return;

                    if (this.CurrentLine == 1)
                    {
                        Regex regex = new Regex(@"Microsoft Visual Studio Solution File, Format Version (\d{2}){1}.(\d{2}){1}$");
                        if (!regex.IsMatch(strLine))
                        {
                            e.Cancel = true;
                            return;
                        }

                        Parsers.Push(CreateParser(ModelTypes.Solution));
                    }
                    else
                    {
                        ParseResult parseResult = null;
                        while (strLine.Length > 0)
                        {
                            Parser parser = Parsers.Peek();
                            parseResult = parser.Parse(strLine);
                            if (!parseResult.Success)
                            {
                                e.Cancel = true;
                                return;
                            }

                            if (parseResult.Model != null)
                            {
                                Parsers.Push(CreateParser(parseResult.Model.Kind));
                                parser = Parsers.Peek();
                            }

                            if ((parser.Model != null) && (parser.Model.Completed))
                            {
                                parser = Parsers.Pop();
                                if (parser.Model.Kind == ModelTypes.Solution)
                                    this.Solution = (Solution)parser.Model;
                            }

                            strLine = strLine.Substring((int)(parseResult.Index + parseResult.Length));
                        }
                    }
                }
            }
        }
        protected void OnFileLoadCompeleted(object sender, LineReadingEventArgs e)
        {
            if (this.Solution != null)
            {
                if (!this.Solution.Valid)
                {
                    this.Solution = null;
                }
            }
        }
    }
}
