using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layer_Models.Neuron_Models;
using Neural_Network_API.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;
using System.Diagnostics;

namespace Neural_Network_API.Neuron_Layer_Models
{
    /// <summary>
    /// The Abstract class for a Neuron Layer.
    /// </summary>
    public abstract class ANeuronLayer : INeuronLayer
    {
        #region Data Members

        /// <summary>
        /// The backing field for NumberOfWeightsPerNeuron.
        /// </summary>
        protected uint _NumberOfWeightsPerNeuron;

        /// <summary>
        /// The Number of Weights Per Neuron in the Layer.
        /// </summary>
        public uint NumberOfWeightsPerNeuron
        {
            get { return this._NumberOfWeightsPerNeuron; }
        }

        /// <summary>
        /// The backing field for NumberOfNeurons.
        /// </summary>
        protected uint _NumberOfNeurons;

        /// <summary>
        /// The Number of Neurons in the Layer.
        /// </summary>
        public uint NumberOfNeurons
        {
            get { return this._NumberOfNeurons; }
        }

        /// <summary>
        /// The The backing field for Neurons.
        /// </summary>
        protected List<INeuron> _Neurons;

        /// <summary>
        /// An Enumerator of the Neurons in the Layer.
        /// </summary>
        public IEnumerator<INeuron> Neurons
        {
            get { return this._Neurons.GetEnumerator(); }
        }

        /// <summary>
        /// The backing field for ActivationFunction.
        /// </summary>
        protected IActivationFunction _ActivationFunction;

        /// <summary>
        /// The Activation Function of all the Neurons in the Layer.
        /// </summary>
        public IActivationFunction ActivationFunction
        {
            get { return this._ActivationFunction; }
        }

        #endregion

        #region CTOR

        /// <summary>
        /// Initalizes an ANeuronLayer.
        /// </summary>
        /// <param name="passedNumberOfNeurons">The Number of Neurons in the Layer.</param>
        /// <param name="passedNumberOfWeightsPerNeuron">The Number of Weights Per Neuron in the Layer.</param>
        /// <param name="passedActivationFunction">The Activation Function of all Neurons in the Layer.</param>
        public ANeuronLayer(uint passedNumberOfNeurons, uint passedNumberOfWeightsPerNeuron, IActivationFunction passedActivationFunction)
        {
            this._Neurons = new List<INeuron>((int)passedNumberOfNeurons);
            this._NumberOfWeightsPerNeuron = passedNumberOfWeightsPerNeuron;
            this._NumberOfNeurons = passedNumberOfNeurons;
            this._ActivationFunction = passedActivationFunction;
            CreateNeurons();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Populates ANeuronLayer._Neurons with INeurons.
        /// </summary>
        protected abstract void CreateNeurons();

        /// <summary>
        /// Gets the Neuron Weights for all Neurons in the Layer.
        /// Note:
        ///     -float[Neuron][Weights]
        /// </summary>
        /// <returns>The Weights for all Neurons in the Layer.</returns>
        public float[][] GetNeuronWeights()
        {
            float[][] result = new float[this.NumberOfNeurons][];
            for (int i = 0; i < this.NumberOfNeurons; i++)
            {
                result[i] = this._Neurons[i].Weights;
            }
            return result;
        }

        /// <summary>
        /// Sets the Weights for all Neurons in the Layer.
        /// </summary>
        /// <param name="passedNeuronWeights">The Weights to assign.</param>
        public void SetNeuronLayerWeights(float[][] passedNeuronWeights)
        {
            Debug.Assert(passedNeuronWeights.Length == this.NumberOfNeurons);
            Debug.Assert(passedNeuronWeights[0].Length == this.NumberOfWeightsPerNeuron);

            for (int i = 0; i < this._Neurons.Count; i++)
            {
                INeuron neuron = this._Neurons[i];
                float[] weightsToAssign = passedNeuronWeights[i];
                neuron.Weights = weightsToAssign;
            }
        }

        /// <summary>
        /// Calculates the Outputs for all Neurons in the Layer given the Input.
        /// Notes:
        ///     -float[Neuron Output]
        /// </summary>
        /// <param name="passedInput">The Input for all Neurons in the Layer.</param>
        /// <returns>The Outputs of all Neurons in the Layer.</returns>
        public float[] CalculateLayerOutput(float[] passedInput)
        {
            float[] result = new float[this._Neurons.Count];
            for (int i = 0; i < this._Neurons.Count; i++)
            {
                INeuron neuron = this._Neurons[i];
                float neuronOutput = neuron.CalculateOutput(passedInput);
                result[i] = neuronOutput;
            }
            return result;
        }

        /// <summary>
        /// Sets the Threshold for all Neurons in the Layer.
        /// </summary>
        /// <param name="passedNeuronThresholds">The Thresholds to assign.</param>
        public void SetNeuronLayerThresholds(float[] passedNeuronThresholds)
        {
            Debug.Assert(passedNeuronThresholds.Length == this._Neurons.Count);

            for (int i = 0; i < this._Neurons.Count; i++)
            {
                INeuron neuron = this._Neurons[i];
                neuron.Threshold = passedNeuronThresholds[i];
            }
        }

        /// <summary>
        /// Gets the Threshold for all Neurons in the Layer.
        /// Notes:
        ///     -float[Threshold]
        /// </summary>
        /// <returns>The Threshold for all Neurons in the Layer.</returns>
        public float[] GetNeuronLayerThresholds()
        {
            float[] result = new float[this._Neurons.Count];
            for (int i = 0; i < this._Neurons.Count; i++)
            {
                INeuron neuron = this._Neurons[i];
                result[i] = neuron.Threshold;
            }
            return result;
        }

        #endregion
    }
}
