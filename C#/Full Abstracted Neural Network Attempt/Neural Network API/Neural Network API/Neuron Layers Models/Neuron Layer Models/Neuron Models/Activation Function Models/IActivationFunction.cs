using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models.Neuron_Input_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Threshold_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models
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
        float CalculateOutput(float passedInput, INeuronThreshold passedThreshold);

        #endregion
    }
}
