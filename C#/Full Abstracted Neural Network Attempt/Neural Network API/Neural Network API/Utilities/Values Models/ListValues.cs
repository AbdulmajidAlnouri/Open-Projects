using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neural_Network_API.Utilities.Values_Models
{
    public class ListValues<T>:IValues<T>
    {
        protected IList<T> _Values;
        public IEnumerator<T> Values
        {
            get { return this._Values.GetEnumerator(); }
        }

        public ListValues(IEnumerable<T> passedValues)
        {
            this._Values = new List<T>(passedValues);
        }
    }
}
