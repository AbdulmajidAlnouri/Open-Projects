using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models;
using Neural_Network_API.Utilities.Values_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Thresholds_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Weights_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Thresholds_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Weights_Models;
using Neural_Network_API.Utilities;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layers_Neuron_Outputs_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Outputs_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models;
namespace Neural_Network_API.Neuron_Layers_Models
{
    public class ANeuronLayers : ListValues<INeuronLayer>, INeuronLayers
    {
        public ANeuronLayers(IEnumerable<INeuronLayer> passedValues)
            : base(passedValues)
        {
        }



        public void SetAllLayerThresholds(INeuronLayersNeuronThresholds passedThresholds)
        {
            IEnumerator<INeuronLayerNeuronThresholds> neuronLayerThresholdsEnumerator = passedThresholds.Values;
            uint neuronLayerIndex = 0;
            while (neuronLayerThresholdsEnumerator.MoveNext())
            {
                INeuronLayerNeuronThresholds currentNeuronLayerNeuronThresholds = neuronLayerThresholdsEnumerator.Current;
                INeuronLayer neuronLayer = this._Values[(int)neuronLayerIndex++];
                neuronLayer.SetNeuronLayerThresholds(currentNeuronLayerNeuronThresholds);
            }
        }

        public INeuronLayersNeuronThresholds GetAllLayerThresholds()
        {
            IList<INeuronLayerNeuronThresholds> neuronLayerThresholds = new List<INeuronLayerNeuronThresholds>((int)this.Values.TotalNumberOfNeurons());
            IEnumerator<INeuronLayer> neuronLayerEnumerator = this.Values;

            while (neuronLayerEnumerator.MoveNext())
            {
                INeuronLayer currentNeuronLayer = neuronLayerEnumerator.Current;
                neuronLayerThresholds.Add(currentNeuronLayer.GetNeuronLayerThresholds());            
            }
            INeuronLayersNeuronThresholds result = new NeuronLayersNeuronThresholds(neuronLayerThresholds);
            return result;
        }

        public void SetAllLayerWeights(INeuronLayersNeuronWeights passedWeights)
        {
            IEnumerator<INeuronLayerNeuronWeights> neuronLayerWeightsEnumerator = passedWeights.Values;
            uint neuronLayerIndex = 0;
            while (neuronLayerWeightsEnumerator.MoveNext())
            {
                INeuronLayerNeuronWeights currentNeuronLayerNeuronWeights = neuronLayerWeightsEnumerator.Current;
                INeuronLayer neuronLayer = this._Values[(int)neuronLayerIndex++];
                neuronLayer.SetNeuronLayerWeights(currentNeuronLayerNeuronWeights);
            }
        }

        public INeuronLayersNeuronWeights GetAllLayerWeights()
        {
            IList<INeuronLayerNeuronWeights> neuronLayerWeights = new List<INeuronLayerNeuronWeights>((int)this.Values.TotalNumberOfWeights());
            IEnumerator<INeuronLayer> neuronLayerEnumerator = this.Values;

            while (neuronLayerEnumerator.MoveNext())
            {
                INeuronLayer currentNeuronLayer = neuronLayerEnumerator.Current;
                neuronLayerWeights.Add(currentNeuronLayer.GetNeuronLayerWeights());
            }
            INeuronLayersNeuronWeights result = new NeuronLayersNeuronWeights(neuronLayerWeights);
            return result;
        }

        public INeuronLayersNeuronOutputs CalculateAllLayersOutputs(INeuronInputs passedInputs)
        {
            IList<INeuronOutputs> neuronLayerNeuronOutputs = new List<INeuronOutputs>(this._Values.Count);

            INeuronInputs layerInputs = passedInputs;
            foreach (INeuronLayer neuronLayer in this._Values)
            {

                INeuronOutputs neuronLayerOutput = neuronLayer.CalculateLayerOutput(layerInputs);


            }

        }
    }
}
