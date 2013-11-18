using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models;
using Neural_Network_API.Utilities.Values_Models;
using System.Collections.Generic;
namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Weights_Models
{
    public class ANeuronLayerNeuronWeights : ListValues<INeuronWeights>, INeuronLayerNeuronWeights
    {

        public ANeuronLayerNeuronWeights(IEnumerable<INeuronWeights> passedValues)
            : base(passedValues)
        {
        }
    }
}
