using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layer_Models;

namespace Neural_Network_API
{
    /// <summary>
    /// The Interface for a Neural Network.
    /// </summary>
    public interface INeuralNetwork
    {
        #region Properties

        /// <summary>
        /// An Enumerator of the INeuronLayers of the Hidden Layers.
        /// </summary>
        IEnumerator<INeuronLayer> HiddenLayers { get; }

        /// <summary>
        /// The INeuronLayer of the Input Layer.
        /// </summary>
        INeuronLayer InputLayer { get; }

        /// <summary>
        /// The INeuronLayer of the Output Layer.
        /// </summary>
        INeuronLayer OutputLayer { get; }

        /// <summary>
        /// All of the INeuronLayers in the Network.
        /// </summary>
        IEnumerator<INeuronLayer> AllLayers { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates Output for the Network.
        /// Notes:
        ///     -float[Neuron Output].
        /// </summary>
        /// <param name="passedInput">The Input for the Network.</param>
        /// <returns>The Output of the Output Layer.</returns>
        float[] CalculateNetworkOutput(float[] passedInput);

        /// <summary>
        /// Gets the Threshold for all Neurons in the Network.
        /// Notes:
        ///     -float[Layer][Thresholds].
        /// </summary>
        /// <returns>The Threshold for all Neurons in the Network.</returns>
        float[][] GetNeuronLayersThresholds();

        /// <summary>
        /// Gets the Neuron Weights for all Neurons in the Network.
        /// Note:
        ///     -float[Layer][Neuron][Weights].
        /// </summary>
        /// <returns>The Weights for all Neurons in the Network.</returns>
        float[][][] GetNeuronLayersWeights();

        /// <summary>
        /// Sets the Threshold for all Neurons in the Network.
        /// Notes:
        ///     -float[Layer][Thresholds].
        /// </summary>
        /// <param name="passedNeuronThresholds">The Thresholds to assign.</param>
        void SetNeuronLayersThresholds(float[][] passedThresholds);

        /// <summary>
        /// Sets the Weights for all Neurons in the Layer.
        /// Notes:
        ///     -float[Layer][Neuron][Weights].
        /// </summary>
        /// <param name="passedNeuronWeights">The Weights to assign.</param>
        void SetNeuronLayersWeights(float[][][] passedWeights);

        #endregion
    }
}
