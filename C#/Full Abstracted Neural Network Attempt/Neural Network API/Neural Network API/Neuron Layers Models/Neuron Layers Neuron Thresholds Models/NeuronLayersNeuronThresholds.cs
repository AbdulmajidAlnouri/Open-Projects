﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Thresholds_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Thresholds_Models
{
    class NeuronLayersNeuronThresholds:ANeuronLayersNeuronThresholds
    {
        public NeuronLayersNeuronThresholds(IEnumerable<INeuronLayerNeuronThresholds> passedValues):base(passedValues)
        {
        }
    }
}