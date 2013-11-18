using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Threshold_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Inputs_Models.Neuron_Input_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Output_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models.Neuron_Activation_Function_Input_Models;

namespace Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models.Neuron_Activation_Function_Models
{
    /// <summary>
    /// The Sigmoid Activation Function. Uses Sigmoid Function: http://en.wikipedia.org/wiki/Sigmoid_function.
    /// </summary>
    public sealed class SigmoidFunction : INeuronActivationFunction
    {
        #region CTORS

       

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the Output for a given Input using the Sigmoid Function.
        /// </summary>
        /// <param name="passedInput">The Input.</param>
        /// <param name="passedThreshold">The Threshold.</param>
        /// <returns>The Output for the Sigmoid Function.</returns>
        public INeuronOutput CalculateOutput(INeuronActivationFunctionInput passedInput, INeuronThreshold passedThreshold)
        {
            float resultValue = (float)(1 / (1 + Math.Exp((-passedInput.Value) / passedThreshold.Value)));
            INeuronOutput result = new NeuronOutput(resultValue);
            return result;
        }

        #endregion
    }
}
