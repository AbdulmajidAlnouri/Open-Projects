using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Weights_Models
{
    public class NeuronLayerNeuronWeights : ANeuronLayerNeuronWeights
    {
        public NeuronLayerNeuronWeights(IEnumerable<INeuronWeights> passedValues)
            : base(passedValues)
        {
        }
    }
}
