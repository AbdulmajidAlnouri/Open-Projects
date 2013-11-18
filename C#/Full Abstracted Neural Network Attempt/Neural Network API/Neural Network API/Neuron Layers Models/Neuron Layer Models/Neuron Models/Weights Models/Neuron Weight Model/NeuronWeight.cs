using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models.Neuron_Weight_Model
{
    /// <summary>
    /// The default implementation of INeuronWeight.
    /// </summary>
    public class NeuronWeight : ANeuronWeight
    {
        
        #region CTOR

        /// <summary>
        /// Initalizes a NeuronWeight.
        /// </summary>
        /// <param name="passedValue">The value to store.</param>
        public NeuronWeight(float passedValue)
            : base(passedValue)
        {
        }

        #endregion
    }
}
