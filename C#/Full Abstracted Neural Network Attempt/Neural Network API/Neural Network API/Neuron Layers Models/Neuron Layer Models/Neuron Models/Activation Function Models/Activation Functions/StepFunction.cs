using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models.Neuron_Input_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Threshold_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models.Activation_Functions
{
    /// <summary>
    /// The Step Activation Function. Uses Step Function: http://en.wikibooks.org/wiki/Artificial_Neural_Networks/Activation_Functions#Step_Function.
    /// </summary>
    public class StepFunction : IActivationFunction
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
        public float CalculateOutput(float passedInput, INeuronThreshold passedThreshold)
        {
            float result = (passedInput >= passedThreshold.Value) ? 1 : 0;
            return result;
        }

        #endregion
    }
}
