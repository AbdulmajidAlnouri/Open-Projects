using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Weights_Models;
using Neural_Network_API.Utilities.Values_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Weights_Models
{
    public class ANeuronLayersNeuronWeights : ListValues<INeuronLayerNeuronWeights>, INeuronLayersNeuronWeights
    {


       public ANeuronLayersNeuronWeights(IEnumerable<INeuronLayerNeuronWeights> passedValues):base(passedValues)
       {       
       }
    }
}
