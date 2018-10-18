using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Vs
{
    internal class ProjectParser : Parser
    {
        public Project Project { get { return base.Model as Project; } }
        public ProjectParser(SolutionFile solutionFile, Project project): base(solutionFile, project)
        {

        }
        protected override ParseResult OnParse(string content)
        {
            ParseResult parseResult = base.OnParse(content);

            Regex regex = new Regex("^Project(\\s*)([(]{1})(\\s*)([\"]{1})(\\s*)([{]{1})([0-9a-zA-Z]{8})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{4})([-]{1})([0-9a-zA-Z]{12})([}]{1})(\\s*)([\"]{1})([)]{1})(\\s*)([=]{1})(\\s*)([\"]{1})([0-9a-zA-Z]{1,255})([\"]{1})(\\s*)([,]{1})(\\s*)([\"]{1})([0-9a-zA-Z\\]{1,255})([\"]{1})(\\s*)");
            if (regex.IsMatch(content))
            {
                int nIndex = content.IndexOf("Project") + ("Project".Length);
                string strTemp = content.Substring(nIndex);
                string[] arrTemp = strTemp.Split('=');
                if (arrTemp.Length >= 1)
                {
                    strTemp = arrTemp[0].Trim();
                    nIndex = strTemp.IndexOf('{');
                    if (nIndex >= 0) {
                        strTemp = strTemp.Substring(nIndex + 1);
                    }
                    nIndex = strTemp.IndexOf('}');
                    if (nIndex >= 0)
                        strTemp = strTemp.Substring(0, nIndex);

                    if((strTemp.Length > 0) && (null != this.Model))
                    {
                        Project project = this.Model as Project;
                        project.SolutionGuid = strTemp.Trim();
                    }
                }

                if(arrTemp.Length >= 2)
                {
                    strTemp = arrTemp[1].Trim();
                    arrTemp = strTemp.Split(',');

                    if(arrTemp.Length >= 1)
                    {
                        strTemp = arrTemp[0].Trim();
                        nIndex = strTemp.IndexOf('\"');
                        if (nIndex >= 0)
                            strTemp = strTemp.Substring(nIndex + 1);
                        nIndex = strTemp.IndexOf('\"');
                        if (nIndex >= 0)
                            strTemp = strTemp.Substring(0, nIndex);


                        if ((strTemp.Length > 0) && (null != this.Model))
                        {
                            Project project = this.Model as Project;
                            project.Name = strTemp;
                        }
                    }

                    if(arrTemp.Length >= 2)
                    {
                        strTemp = arrTemp[1].Trim();
                        nIndex = strTemp.IndexOf('\"');
                        if (nIndex >= 0)
                            strTemp = strTemp.Substring(nIndex + 1);
                        nIndex = strTemp.IndexOf('\"');
                        if (nIndex >= 0)
                            strTemp = strTemp.Substring(0, nIndex);


                        if ((strTemp.Length > 0) && (null != this.Model))
                        {
                            Project project = this.Model as Project;
                            project.Path = strTemp;
                        }
                    }

                    if (arrTemp.Length >= 3)
                    {
                        strTemp = arrTemp[2].Trim();
                        nIndex = strTemp.IndexOf('\"');
                        if (nIndex >= 0)
                            strTemp = strTemp.Substring(nIndex + 1);
                        nIndex = strTemp.IndexOf('\"');
                        if (nIndex >= 0)
                            strTemp = strTemp.Substring(0, nIndex);

                        nIndex = strTemp.IndexOf('{');
                        if (nIndex >= 0)
                            strTemp = strTemp.Substring(nIndex + 1);
                        nIndex = strTemp.IndexOf('}');
                        if (nIndex >= 0)
                            strTemp = strTemp.Substring(0, nIndex);

                        if ((strTemp.Length > 0) && (null != this.Model))
                        {
                            Project project = this.Model as Project;
                            project.Guid = strTemp;
                        }
                    }
                }
            }

            else if(content == "EndProject")
            {
                this.Model.Completed = true;
                this.Model.Valid = this.Model.Validate();
            }

            return parseResult;
        }
    }
}
