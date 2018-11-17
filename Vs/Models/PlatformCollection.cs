using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class PlatformCollection : IEnumerable<Platform>
    {
        Dictionary<string, Platform> _platformCollection = new Dictionary<string, Platform>();
        List<Platform> _platformList = new List<Platform>();

        public IEnumerator<Platform> GetEnumerator()
        {
            return _platformList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _platformList.GetEnumerator();
        }

        public Platform FindPlatform(string name)
        {
            if (_platformCollection.ContainsKey(name))
            {
                return _platformCollection[name];
            }

            return null;
        }

        internal bool Add(Platform prj)
        {
            if (prj == null)
                return false;

            if (prj.Name.Length > 0)
            {
                if (_platformCollection.ContainsKey(prj.Name))
                    return false;

                _platformCollection.Add(prj.Name, prj);
            }

            _platformList.Add(prj);

            return true;
        }

        internal bool Validate()
        {
            foreach (Platform Platform in _platformList)
            {
                if (Platform.Valid)
                {
                    if (!_platformCollection.ContainsKey(Platform.Name))
                    {
                        _platformCollection.Add(Platform.Name, Platform);
                    }
                }
            }
            _platformList.Clear();
            foreach (Platform Platform in _platformCollection.Values)
            {
                _platformList.Add(Platform);
            }

            return true;
        }
    }
}
