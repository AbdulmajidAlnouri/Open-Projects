using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Outputs_Models
{
    public class NeuronLayerNeuronOutputs : ANeuronLayerNeuronOutputs
    {
        public NeuronLayerNeuronOutputs(IEnumerable<INeuronOutputs> passedValues)
            : base(passedValues)
        { 
        
        }

    }
}
