using System.Collections.Generic;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models.Neuron_Output_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models
{
    public class NeuronOutputs : ANeuronOutputs
    {
        public NeuronOutputs(IEnumerable<INeuronOutput> passedValues)
            : base(passedValues)
        {
        }
    }
}
