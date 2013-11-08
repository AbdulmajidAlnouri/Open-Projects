using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Member_Wrapper_API.Values_Models
{
    public abstract class ListValues<T> : IValues<T>
    {
        public IList<T> _Values;
        public IEnumerator<T> Values
        {
            get { return this._Values.GetEnumerator(); }
        }

        public ListValues(IEnumerable<T> passedValues)
        {
            this._Values = passedValues.ToList();
        }
    }
}
