using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layer_Models;
using Neural_Network_API.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;

namespace Neural_Network_API
{
    /// <summary>
    /// The Abstract class for a Neural Network.
    /// </summary>
    public abstract class ANeuralNetwork : INeuralNetwork
    {
        #region Data Members

        /// <summary>
        /// The backing field for InputLayer, HiddenLayers, and OutputLayer.
        /// </summary>
        protected List<INeuronLayer> NeuronLayers;

        /// <summary>
        /// The Input Layer.
        /// </summary>
        public INeuronLayer InputLayer
        {
            get { return this.NeuronLayers.First(); }
        }

        /// <summary>
        /// An Enumerator of the INeuronLayers of the Hidden Layers.
        /// </summary>
        public IEnumerator<INeuronLayer> HiddenLayers
        {
            get { return this.NeuronLayers.Skip(1).Take(this.NeuronLayers.Count - 2).GetEnumerator(); }
        }

        /// <summary>
        /// The Output Layer.
        /// </summary>
        public INeuronLayer OutputLayer
        {
            get { return this.NeuronLayers.Last(); }
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
            this.NeuronLayers = new List<INeuronLayer>((int)passedNumberOfHiddenLayers + 2);

            //Initalize and Assign Input and Output Layers.
            INeuronLayer inputNeuronLayer = new NeuronLayer(passedNumberOfInputNeurons, passedNumberOfWeightsForInput, passedActivationFunction);
            INeuronLayer outputNeuronLayer = new NeuronLayer(passedNumberOfOutputNeurons, passedNumberOfNeuronsPerHiddenLayer, passedActivationFunction);
            this.NeuronLayers[0] = inputNeuronLayer;
            this.NeuronLayers[(int)passedNumberOfHiddenLayers + 1] = outputNeuronLayer;

            for (int i = 1; i < passedNumberOfHiddenLayers; i++)
            {
                this.NeuronLayers[i] = new NeuronLayer(passedNumberOfNeuronsPerHiddenLayer, this.NeuronLayers[i - 1].NumberOfNeurons, passedActivationFunction);
            }
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
        public float[] CalculateNetworkOutput(float[] passedInput)
        {
            float[] layerResult = passedInput;

            for (int i = 0; i < this.NeuronLayers.Count; i++)
            {
                float[] tempOutput = this.NeuronLayers[i].CalculateLayerOutput(layerResult);
                layerResult = tempOutput;
            }

            return layerResult;
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
