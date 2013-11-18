using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Weights_Models.Neuron_Weight_Models;

namespace Neuron_API.Neurons_Models.Neuron_Models.Neuron_Weights_Models
{
    public class NeuronWeights : ANeuronWeights
    {
        public NeuronWeights(IEnumerable<INeuronWeight> passedNeuronWeights)
            : base(passedNeuronWeights)
        {
        }
    }
}
