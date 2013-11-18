using System.Collections.Generic;
using Data_Member_Wrapper_API.Values_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Weights_Models;

namespace Neuron_API.Neurons_Models.Neurons_Weights_Models
{
    public class ANeuronsWeights : ListValues<INeuronWeights>, INeuronsWeights
    {
        public ANeuronsWeights(IEnumerable<INeuronWeights> passedNeuronWeights)
            : base(passedNeuronWeights)
        {

        }

    }
}
