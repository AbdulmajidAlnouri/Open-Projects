using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Threshold_Models;

namespace Neuron_API.Neurons_Models.Neurons_Threshold_Models
{
    public class NeuronsThresholds : ANeuronsThresholds
    {
        public NeuronsThresholds(IEnumerable<INeuronThreshold> passedNeuronThresholds)
            : base(passedNeuronThresholds)
        {

        }
    }
}
