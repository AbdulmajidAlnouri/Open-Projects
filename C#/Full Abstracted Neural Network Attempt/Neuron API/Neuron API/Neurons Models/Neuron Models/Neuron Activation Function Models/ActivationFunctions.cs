using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models.Neuron_Activation_Function_Models;

namespace Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models
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
        public static INeuronActivationFunction STEP_FUNCTION = new StepFunction();

        /// <summary>
        /// The Singleton of the Sigmoid Function.
        /// </summary>
        public static INeuronActivationFunction SIGMOID_FUNCTION = new SigmoidFunction();

        #endregion

    }
}
