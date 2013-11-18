using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Member_Wrapper_API.Values_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Threshold_Models;

namespace Neuron_API.Neurons_Models.Neurons_Threshold_Models
{
    public class ANeuronsThresholds : ListValues<INeuronThreshold>, INeuronsThresholds
    {



        public ANeuronsThresholds(IEnumerable<INeuronThreshold> passedNeuronThresholds)
            : base(passedNeuronThresholds)
        {

        }

    }
}
