using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Utilities.Value_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models.Neuron_Weight_Model
{
    public abstract class ANeuronWeight : AValue<float>, INeuronWeight
    {
        
        #region CTOR

        /// <summary>
        /// Initalizes an ANeuronWeight.
        /// </summary>
        /// <param name="passedValue">The value to store.</param>
        public ANeuronWeight(float passedValue):base(passedValue)
        {
        }

        #endregion


    }
}
