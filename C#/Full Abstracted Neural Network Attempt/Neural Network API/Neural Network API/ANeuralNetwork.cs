using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;
using Neural_Network_API.Neuron_Layers_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models;

namespace Neural_Network_API
{
    /// <summary>
    /// The Abstract class for a Neural Network.
    /// </summary>
    public abstract class ANeuralNetwork : INeuralNetwork
    {
        #region Data Members


        /// <summary>
        /// The Input Layer.
        /// </summary>
        public INeuronLayer GetInputLayer()
        {
            IEnumerator<INeuronLayer> allNeuronLayerEnumerator = this._AllNeuronLayers.Values;
            allNeuronLayerEnumerator.MoveNext();
            INeuronLayer result = allNeuronLayerEnumerator.Current;
            return result;

        }

        /// <summary>
        /// An Enumerator of the INeuronLayers of the Hidden Layers.
        /// </summary>
        public INeuronLayers GetHiddenLayers()
        {

            IList<INeuronLayer> hiddenLayers = new List<INeuronLayer>();
            IEnumerator<INeuronLayer> allNeuronLayerEnumerator = this._AllNeuronLayers.Values;

            //Skip the first element.
            allNeuronLayerEnumerator.MoveNext();
            while (allNeuronLayerEnumerator.MoveNext())
            {
                INeuronLayer current = allNeuronLayerEnumerator.Current;
                hiddenLayers.Add(current);
            }

            //remove the last element
            hiddenLayers.RemoveAt(hiddenLayers.Count - 1);

            INeuronLayers result = new NeuronLayers(hiddenLayers);
            return result;

        }

        /// <summary>
        /// The Output Layer.
        /// </summary>
        public INeuronLayer GetOutputLayer()
        {

            IEnumerator<INeuronLayer> allNeuronLayerEnumerator = this._AllNeuronLayers.Values;
            INeuronLayer lastNeuronLayer = null;
            while (allNeuronLayerEnumerator.MoveNext())
            {
                lastNeuronLayer = allNeuronLayerEnumerator.Current;
            }
            return lastNeuronLayer;

        }


        protected INeuronLayers _AllNeuronLayers;
        public INeuronLayers AllNeuronLayers
        {
            get { return this._AllNeuronLayers; }
        }

        #endregion

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
        public ANeuralNetwork(uint passedNumberOfInputNeurons, uint passedNumberOfNeuronsPerHiddenLayer, uint passedNumberOfHiddenLayers, uint passedNumberOfOutputNeurons, uint passedNumberOfWeightsForInput, IActivationFunction passedActivationFunction)
        {


            //Initalize and Assign Input and Output Layers.
            INeuronLayer inputNeuronLayer = new NeuronLayer(passedNumberOfInputNeurons, passedNumberOfWeightsForInput, passedActivationFunction);
            INeuronLayer outputNeuronLayer = new NeuronLayer(passedNumberOfOutputNeurons, passedNumberOfNeuronsPerHiddenLayer, passedActivationFunction);

            IList<INeuronLayer> neuronLayers = new List<INeuronLayer>((int)(2 + passedNumberOfHiddenLayers));

            neuronLayers.Add(inputNeuronLayer);

            for (int i = 1; i < passedNumberOfHiddenLayers; i++)
            {
                neuronLayers.Add(new NeuronLayer(passedNumberOfNeuronsPerHiddenLayer, neuronLayers[i - 1].NumberOfNeurons, passedActivationFunction));
            }

            neuronLayers.Add(outputNeuronLayer);

            INeuronLayers l = new NeuronLayers(neuronLayers);

        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates Output for the Network.
        /// Notes:
        ///     -float[Neuron Output].
        /// </summary>
        /// <param name="passedInput">The Input for the Network.</param>
        /// <returns>The Output of the Output Layer.</returns>
        public INeuronOutputs CalculateNetworkOutput(INeuronInputs passedInput)
        {


            INeuronInputs nextLayerInput = passedInput;


            IEnumerator<INeuronLayer> neuronLayersEnumeartor = this._AllNeuronLayers.Values;
            INeuronOutputs result;
            while (neuronLayersEnumeartor.MoveNext())
            {
                INeuronLayer currentNeuronLayer = neuronLayersEnumeartor.Current;
                result = currentNeuronLayer.CalculateLayerOutput(nextLayerInput);
                nextLayerInput = result;            
            }
            return result;
        }

        /// <summary>
        /// Sets the Threshold for all Neurons in the Network.
        /// Notes:
        ///     -float[Layer][Thresholds].
        /// </summary>
        /// <param name="passedNeuronThresholds">The Thresholds to assign.</param>
        public void SetNeuronLayersThresholds(float[][] passedThresholds)
        {
            for (int i = 0; i < this.NeuronLayers.Count; i++)
            {
                this.NeuronLayers[i].SetNeuronLayerThresholds(passedThresholds[i]);
            }
        }

        /// <summary>
        /// Gets the Threshold for all Neurons in the Network.
        /// Notes:
        ///     -float[Layer][Thresholds].
        /// </summary>
        /// <returns>The Threshold for all Neurons in the Network.</returns>
        public float[][] GetNeuronLayersThresholds()
        {
            float[][] result = new float[this.NeuronLayers.Count][];

            for (int i = 0; i < this.NeuronLayers.Count; i++)
            {
                result[i] = this.NeuronLayers[i].GetNeuronLayerThresholds();
            }
            return result;

        }

        /// <summary>
        /// Sets the Weights for all Neurons in the Layer.
        /// Notes:
        ///     -float[Layer][Neuron][Weights].
        /// </summary>
        /// <param name="passedNeuronWeights">The Weights to assign.</param>
        public void SetNeuronLayersWeights(float[][][] passedWeights)
        {
            for (int i = 0; i < this.NeuronLayers.Count; i++)
            {
                this.NeuronLayers[i].SetNeuronLayerWeights(passedWeights[i]);
            }
        }

        /// <summary>
        /// Gets the Neuron Weights for all Neurons in the Network.
        /// Note:
        ///     -float[Layer][Neuron][Weights].
        /// </summary>
        /// <returns>The Weights for all Neurons in the Network.</returns>
        public float[][][] GetNeuronLayersWeights()
        {
            float[][][] result = new float[this.NeuronLayers.Count][][];

            for (int i = 0; i < this.NeuronLayers.Count; i++)
            {
                result[i] = this.NeuronLayers[i].GetNeuronWeights();
            }
            return result;
        }

        #endregion



    }
}
