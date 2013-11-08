using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Inputs_Models.Neuron_Input_Models;

namespace Neuron_API.Neurons_Models.Neuron_Models.Neuron_Inputs_Models
{
    public class NeuronInputs : ANeuronInputs
    {
        public NeuronInputs(IEnumerable<INeuronInput> passedNeuronInputs)
            : base(passedNeuronInputs)
        {

        }
    }
}
