using System.Collections.Generic;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models.Neuron_Output_Models;
using Neural_Network_API.Utilities.Values_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models.Neuron_Input_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models
{
    public class ANeuronOutputs : ListValues<INeuronInput>, INeuronOutputs
    {
        public IEnumerator<INeuronOutput> Results
        {
            get { return (IEnumerator<INeuronOutput>)this.Values; }
        }

        public ANeuronOutputs(IEnumerable<INeuronOutput> passedValues)
            : base(passedValues)
        {
        }

        
    }
}
