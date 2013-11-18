using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models;

namespace Neural_Network_API.Neuron_Layers_Models
{
    public class NeuronLayers : ANeuronLayers
    {
        public NeuronLayers(IEnumerable<INeuronLayer> passedValues)
            : base(passedValues)
        {
        }
    }
}
