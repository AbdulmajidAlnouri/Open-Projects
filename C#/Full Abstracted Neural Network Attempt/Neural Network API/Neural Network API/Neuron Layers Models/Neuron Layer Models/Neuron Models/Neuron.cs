using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models
{
    /// <summary>
    /// The Default Implementation of INeuron.
    /// </summary>
    public class Neuron : ANeuron
    {
        #region CTOR

        /// <summary>
        /// Initalizes a Neuron.
        /// Notes:
        ///     -Initalizes Threshold to a Random Float.
        /// </summary>
        /// <param name="passedNumberOfWeights">The Number of Weights for the Neuron.</param>
        /// <param name="passedActivationFunction">The Activation Function for the Neuron</param>
        public Neuron(uint passedNumberOfWeights, IActivationFunction passedActivationFunction)
            : base(passedNumberOfWeights, passedActivationFunction)
        {
        }

        /// Initalizes a Neuron.
        /// </summary>
        /// <param name="passedNumberOfWeights">The Number of Weights for the Neuron.</param>
        /// <param name="passedThreshold">The Threshold for the Neuron.</param>
        /// <param name="passedActivationFunction">The Activation Function for the Neuron</param>
        public Neuron(uint passedNumberOfWeights, float passedThreshold, IActivationFunction passedActivationFunction)
            : base(passedNumberOfWeights, passedThreshold, passedActivationFunction)
        {
        }

        #endregion CTOR
    }
}
