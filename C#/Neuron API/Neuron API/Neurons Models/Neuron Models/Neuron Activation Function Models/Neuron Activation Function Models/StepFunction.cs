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
    /// The Step Activation Function. Uses Step Function: http://en.wikibooks.org/wiki/Artificial_Neural_Networks/Activation_Functions#Step_Function.
    /// </summary>
    public class StepFunction : INeuronActivationFunction
    {
        #region CTORS

        /// <summary>
        /// Initalizes StepFunction.
        /// </summary>
        public StepFunction()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the Output for a given Input using the Step Function.
        /// </summary>
        /// <param name="passedInput">The Input.</param>
        /// <param name="passedThreshold">The Threshold.</param>
        /// <returns>The Output for the Step Function.</returns>
        public INeuronOutput CalculateOutput(INeuronActivationFunctionInput passedInput, INeuronThreshold passedThreshold)
        {
            float resultValue = (passedInput.Value >= passedThreshold.Value) ? 1 : 0;
            INeuronOutput result = new NeuronOutput(resultValue);
            return result;
        }

        #endregion

       
    }
}
