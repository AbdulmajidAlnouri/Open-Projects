using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Thresholds_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Weights_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Outputs_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models
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
        void SetNeuronLayerThresholds(INeuronLayerNeuronThresholds passedNeuronThresholds);

        /// <summary>
        /// Sets the Weights for all Neurons in the Layer.
        /// </summary>
        /// <param name="passedNeuronWeights">The Weights to assign.</param>
        void SetNeuronLayerWeights(INeuronLayerNeuronWeights passedNeuronWeights);

        /// <summary>
        /// Gets the Threshold for all Neurons in the Layer.
        /// Notes:
        ///     -float[Threshold]
        /// </summary>
        /// <returns>The Threshold for all Neurons in the Layer.</returns>
        INeuronLayerNeuronThresholds GetNeuronLayerThresholds();


        INeuronLayerNeuronWeights GetNeuronLayerWeights();

        /// <summary>
        /// Calculates the Outputs for all Neurons in the Layer given the Input.
        /// Notes:
        ///     -float[Neuron Output]
        /// </summary>
        /// <param name="passedInput">The Input for all Neurons in the Layer.</param>
        /// <returns>The Outputs of all Neurons in the Layer.</returns>
        INeuronLayerNeuronOutputs CalculateLayerOutput(INeuronInputs passedInput);

        #endregion
    }
}
