using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models;
using Data_Member_Wrapper_API.Values_Models;

namespace Neuron_API.Neurons_Models.Neurons_Activation_Functions_Models
{
    public class ANeuronsNeuronActivationFunctions : ListValues<INeuronActivationFunction>, INeuronsNeuronActivationFunctions
    {

        public ANeuronsNeuronActivationFunctions(IEnumerable<INeuronActivationFunction> passedNeuronActivationFunctions):base(passedNeuronActivationFunctions)
        {

        }
    }
}
