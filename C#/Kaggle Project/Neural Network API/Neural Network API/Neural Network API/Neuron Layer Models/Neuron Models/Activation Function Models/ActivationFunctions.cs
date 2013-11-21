using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models.Activation_Functions;

namespace Neural_Network_API.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models
{
    /// <summary>
    /// Static Class containing Singletons of common Activation Functions.
    /// </summary>
    public static class ActivationFunctions
    {
        #region Data Members
        /// <summary>
        /// The Singleton of the Step Function.
        /// </summary>
        public static IActivationFunction STEP_FUNCTION = new StepFunction();

        /// <summary>
        /// The Singleton of the Sigmoid Function.
        /// </summary>
        public static IActivationFunction SIGMOID_FUNCTION = new SigmoidFunction();

        #endregion 

    }
}
