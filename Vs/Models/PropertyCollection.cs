using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vs
{
    public class PropertyCollection : IEnumerable<Property>
    {
        Dictionary<string, Property> _propertyCollection = new Dictionary<string, Property>();
        List<Property> _propertyList = new List<Property>();

        public IEnumerator<Property> GetEnumerator()
        {
            return _propertyList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _propertyList.GetEnumerator();
        }

        public Property Get(string name)
        {
            if (_propertyCollection.ContainsKey(name))
            {
                return _propertyCollection[name];
            }

            return null;
        }

        internal bool Add(Property property)
        {
            if (property == null)
                return false;

            if (property.Name.Length > 0)
            {
                if (_propertyCollection.ContainsKey(property.Name))
                    return false;

                _propertyCollection.Add(property.Name, property);
            }

            _propertyList.Add(property);

            return true;
        }
    }
}
