﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Thresholds_Models;
using Neural_Network_API.Utilities.Values_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Thresholds_Models
{
    public class ANeuronLayersNeuronThresholds : ListValues<INeuronLayerNeuronThresholds>, INeuronLayersNeuronThresholds
    {
        public ANeuronLayersNeuronThresholds(IEnumerable<INeuronLayerNeuronThresholds> passedValues)
            : base(passedValues)
        {
        }
    }
}
