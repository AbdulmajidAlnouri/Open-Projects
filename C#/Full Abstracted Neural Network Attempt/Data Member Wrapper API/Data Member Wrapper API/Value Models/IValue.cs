using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Member_Wrapper_API.Value_Models
{
    public interface IValue<T>
    {
        T Value { get; }
    }
}
