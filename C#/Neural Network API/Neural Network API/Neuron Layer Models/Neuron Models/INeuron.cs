using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;

namespace Neural_Network_API.Neuron_Layer_Models.Neuron_Models
{
    /// <summary>
    /// The Interface for a Neuron.
    /// </summary>
    public interface INeuron
    {
        #region Properties

        /// <summary>
        /// The Threshold for the Neuron.
        /// </summary>
        float Threshold { get; set; }

        /// <summary>
        /// The Weights for the Neuron.
        /// </summary>
        float[] Weights { get; set; }

        /// <summary>
        /// The Activation Function of the Neuron.
        /// </summary>
        IActivationFunction ActivationFunction { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the Output for the Neuron given the Input.
        /// </summary>
        /// <param name="passedInput">The Input for the Neuron.</param>
        /// <returns>The Output of the Neuron.</returns>
        float CalculateOutput(float[] passedInput);

        #endregion
    }
}
