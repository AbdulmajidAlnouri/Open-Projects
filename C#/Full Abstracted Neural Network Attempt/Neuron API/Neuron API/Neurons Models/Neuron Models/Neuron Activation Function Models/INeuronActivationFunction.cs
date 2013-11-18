using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Inputs_Models.Neuron_Input_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Output_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Threshold_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models.Neuron_Activation_Function_Input_Models;

namespace Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models
{
    public interface INeuronActivationFunction
    {
        INeuronOutput CalculateOutput(INeuronActivationFunctionInput passedInputs, INeuronThreshold passedThreshold);
    }
}
