using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;

namespace Neural_Network_API
{
    /// <summary>
    /// The Default Implementation of INeuralNetwork.
    /// </summary>
    public class NeuralNetwork : ANeuralNetwork
    {
        #region CTOR

        /// <summary>
        /// Initalizes an ANeuralNetwork.
        /// </summary>
        /// <param name="passedNumberOfInputNeurons">The Number of Neurons in the Input Layer.</param>
        /// <param name="passedNumberOfNeuronsPerHiddenLayer">The Number of Neurons in the Hidden Layers.</param>
        /// <param name="passedNumberOfHiddenLayers">The Number of Hidden Layers.</param>
        /// <param name="passedNumberOfOutputNeurons">The Number of Neurons in the Output Layer.</param>
        /// <param name="passedNumberOfWeightsForInput">The Number of Weights for an Input Neuron.</param>
        /// <param name="passedActivationFunction">The Activation Function for all Neurons in the Network.</param>
        public NeuralNetwork(uint passedNumberOfInputNeurons, uint passedNumberOfNeuronsPerHiddenLayer, uint passedNumberOfHiddenLayers, uint passedNumberOfOutputNeurons, uint passedNumberOfWeightsForInput, IActivationFunction passedActivationFunction)
            : base(passedNumberOfInputNeurons, passedNumberOfNeuronsPerHiddenLayer, passedNumberOfHiddenLayers, passedNumberOfOutputNeurons, passedNumberOfWeightsForInput, passedActivationFunction)
        { }

        #endregion
    }
}
