using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neural_Network_API.Utilities.Values_Models
{
    public interface IValues<T>
    {
        IEnumerator<T> Values { get; }
    }
}
