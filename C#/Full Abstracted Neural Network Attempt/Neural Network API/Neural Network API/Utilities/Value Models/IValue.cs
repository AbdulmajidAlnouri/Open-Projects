using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neural_Network_API.Utilities.Value_Models
{
    public interface IValue<T>
    {
        T Value { get; }
    }
}
