using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Member_Wrapper_API.Values_Models;
using Neuron_API.Neurons_Models.Neuron_Models;

namespace Neuron_API.Neurons_Models
{
    public class ANeurons : ListValues<INeuron>, INeurons
    {


        public ANeurons(IEnumerable<INeuron> passedNeurons):base(passedNeurons)
        {
        }
    }
}
