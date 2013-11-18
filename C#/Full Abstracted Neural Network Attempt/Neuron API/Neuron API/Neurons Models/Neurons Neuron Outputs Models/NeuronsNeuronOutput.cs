using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Output_Models;

namespace Neuron_API.Neurons_Models.Neurons_Neuron_Outputs_Models
{
    public class NeuronsNeuronOutput : ANeuronsNeuronOutput
    {
        public NeuronsNeuronOutput(IEnumerable<INeuronOutput> passedNeuronOutputs)
            : base(passedNeuronOutputs)
        {
        }
    }
}
