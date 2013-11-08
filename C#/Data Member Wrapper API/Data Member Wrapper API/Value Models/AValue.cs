using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Member_Wrapper_API.Value_Models
{
    public abstract class AValue<T> : IValue<T>
    {
        public T _Value;
        public T Value
        {
            get { return this._Value; }
        }


        public AValue(T passedValue)
        {

        }
    }
}
