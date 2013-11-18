using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models.Neuron_Weight_Model;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models
{
    /// <summary>
    /// The default implementation of INeuronWeights.
    /// </summary>
    public class NeuronWeights : ANeuronWeights
    {
        
        #region CTOR

        /// <summary>
        /// Initalizes a NeuronWeights.
        /// </summary>
        /// <param name="passedNeuronWeights"></param>
        public NeuronWeights(IEnumerable<INeuronWeight> passedNeuronWeights):base(passedNeuronWeights)
        {
        }

        #endregion
   
    }
}
