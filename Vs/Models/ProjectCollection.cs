using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ProjectCollection : IEnumerable<Project>
    {
        Dictionary<string, Project> _projectCollection = new Dictionary<string, Project>();
        List<Project> _projectList = new List<Project>();

        public IEnumerator<Project> GetEnumerator()
        {
            return _projectList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _projectList.GetEnumerator();
        }

        public Project FindProject(string name)
        {
            if (_projectCollection.ContainsKey(name))
            {
                return _projectCollection[name];
            }

            return null;
        }

        internal bool Add(Project prj)
        {
            if (prj == null)
                return false;

            if (prj.Name.Length > 0)
            {
                if (_projectCollection.ContainsKey(prj.Name))
                    return false;

                _projectCollection.Add(prj.Name, prj);
            }

            _projectList.Add(prj);

            return true;
        }

        internal bool Validate()
        {
            foreach(Project Project in _projectList)
            {
                if (Project.Valid)
                {
                    if (!_projectCollection.ContainsKey(Project.Name))
                    {
                        _projectCollection.Add(Project.Name, Project);
                    }
                }
            }
            _projectList.Clear();
            foreach(Project Project in _projectCollection.Values)
            {
                _projectList.Add(Project);
            }

            return true;
        }
    }
}
