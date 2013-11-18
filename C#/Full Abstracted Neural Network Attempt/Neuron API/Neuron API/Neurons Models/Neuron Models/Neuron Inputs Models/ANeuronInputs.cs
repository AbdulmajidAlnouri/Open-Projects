using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Member_Wrapper_API.Values_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Inputs_Models.Neuron_Input_Models;

namespace Neuron_API.Neurons_Models.Neuron_Models.Neuron_Inputs_Models
{
    public class ANeuronInputs : ListValues<INeuronInput>, INeuronInputs
    {


        public ANeuronInputs(IEnumerable<INeuronInput> passedNeuronInputs):base(passedNeuronInputs)
        {

        }

    }
}
