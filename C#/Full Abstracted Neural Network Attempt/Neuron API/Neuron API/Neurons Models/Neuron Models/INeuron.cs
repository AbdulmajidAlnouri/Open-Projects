using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Threshold_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Weights_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Output_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Inputs_Models;

namespace Neuron_API.Neurons_Models.Neuron_Models
{
    public interface INeuron
    {
        INeuronThreshold Threshold { get; set; }
        
        INeuronWeights Weights { get; set; }

        INeuronActivationFunction ActivationFunction { get; set; }


        
        INeuronOutput CalculateOutput(INeuronInputs passedInput);
    }
}
