using System.Collections.Generic;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Weights_Models;
using Neuron_API.Neurons_Models.Neurons_Weights_Models;

namespace Neuron_API.Neurons_Models.Neurons_Threshold_Models
{
    public class NeuronsWeights : ANeuronsWeights
    {
        public NeuronsWeights(IEnumerable<INeuronWeights> passedNeuronWeights)
            : base(passedNeuronWeights)
        {

        }
    }
}
