using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Member_Wrapper_API.Value_Models;

namespace Neuron_API.Neurons_Models.Neuron_Models.Neuron_Value_Models
{
    public abstract class ANeuronValue : AValue<float>, INeuronValue
    {
        public ANeuronValue(float passedNeuronValue):base(passedNeuronValue)
        {
        }
    }
}
