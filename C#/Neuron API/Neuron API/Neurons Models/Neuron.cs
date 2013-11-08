using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neuron_API.Neurons_Models.Neuron_Models;

namespace Neuron_API.Neurons_Models
{
    public class Neurons:ANeurons
    {
        public Neurons(IEnumerable<INeuron> passedNeurons):base(passedNeurons)
        {
        }
    }
}
