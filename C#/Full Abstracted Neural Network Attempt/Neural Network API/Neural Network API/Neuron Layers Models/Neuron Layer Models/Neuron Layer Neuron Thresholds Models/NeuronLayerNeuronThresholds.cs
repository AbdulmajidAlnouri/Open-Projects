using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Threshold_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Thresholds_Models
{
    public class NeuronLayerNeuronThresholds : ANeuronLayerNeuronThresholds
    {
        public NeuronLayerNeuronThresholds(IEnumerable<INeuronThreshold> passedValues)
            : base(passedValues)
        {}
    }
}
