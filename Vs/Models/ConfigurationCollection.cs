using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class ConfigurationCollection : IEnumerable<Configuration>
    {
        Dictionary<string, Configuration> _configurationCollection = new Dictionary<string, Configuration>();
        List<Configuration> _configurationList = new List<Configuration>();

        public IEnumerator<Configuration> GetEnumerator()
        {
            return _configurationList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _configurationList.GetEnumerator();
        }

        public Configuration FindConfiguration(string name)
        {
            if (_configurationCollection.ContainsKey(name))
            {
                return _configurationCollection[name];
            }

            return null;
        }

        internal bool Add(Configuration prj)
        {
            if (prj == null)
                return false;

            if (prj.Name.Length > 0)
            {
                if (_configurationCollection.ContainsKey(prj.Name))
                    return false;

                _configurationCollection.Add(prj.Name, prj);
            }

            _configurationList.Add(prj);

            return true;
        }

        internal bool Validate()
        {
            foreach (Configuration Configuration in _configurationList)
            {
                if (Configuration.Valid)
                {
                    if (!_configurationCollection.ContainsKey(Configuration.Name))
                    {
                        _configurationCollection.Add(Configuration.Name, Configuration);
                    }
                }
            }
            _configurationList.Clear();
            foreach (Configuration Configuration in _configurationCollection.Values)
            {
                _configurationList.Add(Configuration);
            }

            return true;
        }
    }
}
