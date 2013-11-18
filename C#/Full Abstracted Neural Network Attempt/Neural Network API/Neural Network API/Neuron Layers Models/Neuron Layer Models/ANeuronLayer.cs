using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;
using System.Diagnostics;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Weights_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models.Neuron_Weight_Model;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Layer_Neuron_Thresholds_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Threshold_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models.Neuron_Output_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models
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
        /// Each weights instance contains all the weights for a neuron.
        /// </summary>
        /// <returns></returns>
        public INeuronLayerNeuronWeights GetNeuronLayerWeights()
        {
            IList<INeuronWeights> neuronWeights = new List<INeuronWeights>((int)this.NumberOfNeurons);

            foreach (INeuron neuron in this._Neurons)
            {
                neuronWeights.Add(neuron.Weights);
            }

            INeuronLayerNeuronWeights result = new NeuronLayerNeuronWeights(neuronWeights);
            return result;
        }


        public void SetNeuronLayerWeights(INeuronLayerNeuronWeights passedNeuronWeights)
        {
            IEnumerator<INeuronWeights> neuronWeightsEnumerator = passedNeuronWeights.Values;
            uint neuronIndex = 0;
            while (neuronWeightsEnumerator.MoveNext())
            {
                INeuronWeights current = neuronWeightsEnumerator.Current;
                INeuron neuron = this._Neurons[(int)neuronIndex++];
                neuron.Weights = current;            
            }
        }

        /// <summary>
        /// Calculates the Outputs for all Neurons in the Layer given the Input.
        /// Notes:
        ///     -float[Neuron Output]
        /// </summary>
        /// <param name="passedInput">The Input for all Neurons in the Layer.</param>
        /// <returns>The Outputs of all Neurons in the Layer.</returns>
        public INeuronOutputs CalculateLayerOutput(INeuronInputs passedInput)
        {
            IList<INeuronOutput> outputs = new List<INeuronOutput>((int)this.NumberOfNeurons);
            
            for (int i = 0; i < this._Neurons.Count; i++)
            {
                INeuron neuron = this._Neurons[i];
                INeuronOutput neuronOutput = neuron.CalculateOutput(passedInput);
                outputs.Add(neuronOutput);
            }
            INeuronOutputs result = new NeuronOutputs(outputs);
            return result;
        }


        public void SetNeuronLayerThresholds(INeuronLayerNeuronThresholds passedNeuronThresholds)
        {
            IEnumerator<INeuronThreshold> neuronThresholdsEnumerator = passedNeuronThresholds.Values;
            uint neuronIndex = 0;
            while (neuronThresholdsEnumerator.MoveNext())
            {
                INeuronThreshold current = neuronThresholdsEnumerator.Current;
                INeuron neuron = this._Neurons[(int)neuronIndex++];
                neuron.Threshold = current;
            }
        }

        /// <summary>
        /// Gets the Threshold for all Neurons in the Layer.
        /// Notes:
        ///     -float[Threshold]
        /// </summary>
        /// <returns>The Threshold for all Neurons in the Layer.</returns>
        public INeuronLayerNeuronThresholds GetNeuronLayerThresholds()
        {
            IList<INeuronThreshold> neuronThresholds = new List<INeuronThreshold>((int)this.NumberOfNeurons);

            foreach (INeuron neuron in this._Neurons)
            {
                neuronThresholds.Add(neuron.Threshold);
            }

            INeuronLayerNeuronThresholds result = new NeuronLayerNeuronThresholds(neuronThresholds);
            return result;
        }

        #endregion
    }
}
