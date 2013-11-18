using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models;
using Neural_Network_API.Utilities.Values_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Outputs_Models
{
    public class ANeuronLayerNeuronOutputs : ListValues<INeuronOutputs>, INeuronLayerNeuronOutputs
    {
        public ANeuronLayerNeuronOutputs(IEnumerable<INeuronOutputs> passedValues)
            : base(passedValues)
        { 
        
        }
    }
}
