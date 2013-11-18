using System.Collections.Generic;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models;
using Neural_Network_API.Neuron_Layers_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Thresholds_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Weights_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Thresholds_Models;

namespace Neural_Network_API
{
    /// <summary>
    /// The Interface for a Neural Network.
    /// </summary>
    public interface INeuralNetwork
    {
        #region Properties


        INeuronLayers GetHiddenLayers();


        INeuronLayer GetInputLayer();


        INeuronLayer GetOutputLayer();


        INeuronLayers AllLayers { get; }

        #endregion

        #region Methods

        float[] CalculateNetworkOutput(float[] passedInput);

        INeuronLayersNeuronThresholds GetNeuronLayersThresholds();

        INeuronLayersNeuronWeights GetNeuronLayersWeights();

        void SetNeuronLayersThresholds(INeuronLayersNeuronThresholds passedThresholds);

        void SetNeuronLayersWeights(INeuronLayersNeuronWeights passedWeights);

        #endregion
    }
}
