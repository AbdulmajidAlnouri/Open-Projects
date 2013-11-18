using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Utilities.Values_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Outputs_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Outputs_Models
{
    public class ANeuronLayersNeuronOutputs : ListValues<INeuronLayerNeuronOutputs>, INeuronLayersNeuronOutputs
    {
        public ANeuronLayersNeuronOutputs(IEnumerable<INeuronLayerNeuronOutputs> passedValues)
            : base(passedValues)
        { 
        }
    }
}
