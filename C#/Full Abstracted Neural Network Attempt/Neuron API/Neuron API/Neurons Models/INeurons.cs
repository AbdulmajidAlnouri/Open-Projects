using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Member_Wrapper_API.Values_Models;
using Neuron_API.Neurons_Models.Neuron_Models;
using Neuron_API.Neurons_Models.Neurons_Threshold_Models;
using Neuron_API.Neurons_Models.Neurons_Weights_Models;
using Neuron_API.Neurons_Models.Neurons_Activation_Functions_Models;
using Neuron_API.Neurons_Models.Neurons_Neuron_Outputs_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Inputs_Models;

namespace Neuron_API.Neurons_Models
{
    public interface INeurons:IValues<INeuron>
    {
        INeuronsThresholds GetNeuronsThresholds();
        void SetNeuronsThresholds(INeuronsThresholds passedNeuronsThresholds);


        INeuronsWeights GetNeuronsWeights();
        void SetNeuronsWeights(INeuronsWeights passedNeuronsWeights);

        INeuronsNeuronActivationFunctions GetNeuronsNeuronActivationFunctions();
        void SetNeuronsNeuronActivationFunctions(INeuronsNeuronActivationFunctions passedNeuronsNeuronActivationFunctions);

        INeuronsNeuronOutput CalculateNeuronsOutput(INeuronInputs passedNeuronInputs);
    }
}
