using System.Collections.Generic;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models.Neuron_Input_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models
{
    class NeuronInputs : ANeuronInputs
    {
        public NeuronInputs(IEnumerable<INeuronInput> passedValues)
            : base(passedValues)
        {
        }
    }
}
