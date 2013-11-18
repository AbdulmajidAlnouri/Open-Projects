using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models.Neuron_Weight_Model;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models
{
    public interface INeuronWeights
    {
        IEnumerator<INeuronWeight> Weights { get; }
    }
}
