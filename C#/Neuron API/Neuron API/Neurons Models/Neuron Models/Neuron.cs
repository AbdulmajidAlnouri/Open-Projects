using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Weights_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Threshold_Models;

namespace Neuron_API.Neurons_Models.Neuron_Models
{
    public class Neuron : ANeuron
    {
        
        public Neuron(uint passedNumberOfWeights, INeuronActivationFunction passedActivationFunction):base(passedNumberOfWeights, passedActivationFunction)
        {
        }

        public Neuron(uint passedNumberOfWeights, INeuronThreshold passedThreshold, INeuronActivationFunction passedActivationFunction):base( passedNumberOfWeights, passedThreshold, passedActivationFunction)
        {
        }

        public Neuron(INeuronWeights passedNeuronWeights, INeuronActivationFunction passedActivationFunction):base(passedNeuronWeights, passedActivationFunction)
        {
        }

        public Neuron(INeuronWeights passedNeuronWeights, INeuronThreshold passedThreshold, INeuronActivationFunction passedActivationFunction):base( passedNeuronWeights, passedThreshold, passedActivationFunction)
        {
        }


        
    }
}
