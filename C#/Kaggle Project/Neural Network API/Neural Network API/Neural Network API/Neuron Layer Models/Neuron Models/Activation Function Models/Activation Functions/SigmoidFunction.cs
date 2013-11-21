using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neural_Network_API.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models.Activation_Functions
{
    /// <summary>
    /// The Sigmoid Activation Function. Uses Sigmoid Function: http://en.wikipedia.org/wiki/Sigmoid_function.
    /// </summary>
    public class SigmoidFunction : IActivationFunction
    {
        #region CTORS

        /// <summary>
        /// Initalizes SigmoidFunction.
        /// </summary>
        public SigmoidFunction()
        {
        }

        #endregion

        #region Methods 

        /// <summary>
        /// Calculates the Output for a given Input using the Sigmoid Function.
        /// </summary>
        /// <param name="passedInput">The Input.</param>
        /// <param name="passedThreshold">The Threshold.</param>
        /// <returns>The Output for the Sigmoid Function.</returns>
        public float CalculateOutput(float passedInput, float passedThreshold)
        {
            float result = (float)(1 / (1 + Math.Exp(-passedInput)));
            return result;
        }

        #endregion
    }
}
