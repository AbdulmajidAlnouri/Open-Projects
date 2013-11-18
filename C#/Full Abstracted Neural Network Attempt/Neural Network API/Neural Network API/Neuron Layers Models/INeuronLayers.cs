using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models;
using Neural_Network_API.Utilities.Values_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Weights_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Thresholds_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Outputs_Models;

namespace Neural_Network_API.Neuron_Layers_Models
{
    public interface INeuronLayers : IValues<INeuronLayer>
    {
        void SetAllLayerThresholds(INeuronLayersNeuronThresholds passedThresholds);
        INeuronLayersNeuronThresholds GetAllLayerThresholds();

        void SetAllLayerWeights(INeuronLayersNeuronWeights passedWeights);
        INeuronLayersNeuronWeights GetAllLayerWeights();

        INeuronLayersNeuronOutputs CalculateAllLayersOutputs();
    }
}
