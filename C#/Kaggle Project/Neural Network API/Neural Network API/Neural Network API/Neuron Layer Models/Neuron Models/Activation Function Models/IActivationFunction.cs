using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neural_Network_API.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models
{
    /// <summary>
    /// Interface for an Activation Function.
    /// </summary>
    public interface IActivationFunction
    {
        #region Methods

        /// <summary>
        /// Calculates the Output for a given Input.
        /// </summary>
        /// <param name="passedInput">The Input.</param>
        /// <param name="passedThreshold">The Threshold.</param>
        /// <returns>The Output for the Activation Function.</returns>
        float CalculateOutput(float passedInput, float passedThreshold);

        #endregion
    }
}
