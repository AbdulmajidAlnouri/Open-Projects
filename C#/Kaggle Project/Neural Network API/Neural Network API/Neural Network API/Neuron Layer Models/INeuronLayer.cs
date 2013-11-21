using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layer_Models.Neuron_Models;
using Neural_Network_API.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;

namespace Neural_Network_API.Neuron_Layer_Models
{
    /// <summary>
    /// The Interface for a Neuron Layer.
    /// </summary>
    public interface INeuronLayer
    {
        #region Properties

        /// <summary>
        /// The Number of Weights Per Neuron in the Layer.
        /// </summary>
        uint NumberOfWeightsPerNeuron { get; }

        /// <summary>
        /// The Number of Neurons in the Layer.
        /// </summary>
        uint NumberOfNeurons { get; }

        /// <summary>
        /// An Enumerator of the Neurons in the Layer.
        /// </summary>
        IEnumerator<INeuron> Neurons { get; }

        /// <summary>
        /// The Activation Function of all the Neurons in the Layer.
        /// </summary>
        IActivationFunction ActivationFunction { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the Threshold for all Neurons in the Layer.
        /// </summary>
        /// <param name="passedNeuronThresholds">The Thresholds to assign.</param>
        void SetNeuronLayerThresholds(float[] passedNeuronThresholds);

        /// <summary>
        /// Sets the Weights for all Neurons in the Layer.
        /// </summary>
        /// <param name="passedNeuronWeights">The Weights to assign.</param>
        void SetNeuronLayerWeights(float[][] passedNeuronWeights);

        /// <summary>
        /// Gets the Threshold for all Neurons in the Layer.
        /// Notes:
        ///     -float[Threshold]
        /// </summary>
        /// <returns>The Threshold for all Neurons in the Layer.</returns>
        float[] GetNeuronLayerThresholds();

        /// <summary>
        /// Gets the Neuron Weights for all Neurons in the Layer.
        /// Note:
        ///     -float[Neuron][Weights]
        /// </summary>
        /// <returns>The Weights for all Neurons in the Layer.</returns>
        float[][] GetNeuronWeights();

        /// <summary>
        /// Calculates the Outputs for all Neurons in the Layer given the Input.
        /// Notes:
        ///     -float[Neuron Output]
        /// </summary>
        /// <param name="passedInput">The Input for all Neurons in the Layer.</param>
        /// <returns>The Outputs of all Neurons in the Layer.</returns>
        float[] CalculateLayerOutput(float[] passedInput);

        #endregion
    }
}
