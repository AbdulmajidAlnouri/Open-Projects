using System.Collections.Generic;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models.Neuron_Input_Models;
using Neural_Network_API.Utilities.Values_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models
{
    public class ANeuronInputs : ListValues<INeuronInput>, INeuronInputs
    {
        public ANeuronInputs(IEnumerable<INeuronInput> passedValues)
            : base(passedValues)
        {
        }
    }
}
