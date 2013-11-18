using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Member_Wrapper_API.Values_Models
{
    public interface IValues<T> 
    {
        IEnumerator<T> Values { get; }
    }
}
