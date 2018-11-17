using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Vs
{
    public class GlobalSectionCollection : IEnumerable<GlobalSection>
    {
        Dictionary<string, GlobalSection> _sectionCollection = new Dictionary<string, GlobalSection>();
        List<GlobalSection> _sectionList = new List<GlobalSection>();

        public IEnumerator<GlobalSection> GetEnumerator()
        {
            return _sectionList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _sectionList.GetEnumerator();
        }

        public GlobalSection FindSection(string name)
        {
            if (_sectionCollection.ContainsKey(name))
            {
                return _sectionCollection[name];
            }

            foreach(GlobalSection section in _sectionList)
            {
                if (section.Name.CompareTo(name) == 0)
                    return section;
            }

            return null;
        }

        internal bool Add(GlobalSection prj)
        {
            if (prj == null)
                return false;

            if (prj.Name.Length > 0)
            {
                if (_sectionCollection.ContainsKey(prj.Name))
                    return false;

                _sectionCollection.Add(prj.Name, prj);
            }

            _sectionList.Add(prj);

            return true;
        }

        internal bool Validate()
        {
            foreach (GlobalSection GlobalSection in _sectionList)
            {
                if (GlobalSection.Valid)
                {
                    if (!_sectionCollection.ContainsKey(GlobalSection.Name))
                    {
                        _sectionCollection.Add(GlobalSection.Name, GlobalSection);
                    }
                }
            }
            _sectionList.Clear();
            foreach (GlobalSection GlobalSection in _sectionCollection.Values)
            {
                _sectionList.Add(GlobalSection);
            }

            return true;
        }
    }
}
