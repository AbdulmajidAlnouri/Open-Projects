using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models
{
    /// <summary>
    /// The Default Implementation of INeuronLayer.
    /// </summary>
    public class NeuronLayer : ANeuronLayer
    {

        #region CTOR

        /// <summary>
        /// Initalizes a NeuronLayer.
        /// </summary>
        /// <param name="passedNumberOfNeurons">The Number of Neurons in the Layer.</param>
        /// <param name="passedNumberOfWeightsPerNeuron">The Number of Weights Per Neuron in the Layer.</param>
        /// <param name="passedActivationFunction">The Activation Function of all Neurons in the Layer.</param>
        public NeuronLayer(uint passedNumberOfNeurons, uint passedNumberOfWeightsPerNeuron, IActivationFunction passedActivationFunction)
            : base(passedNumberOfNeurons, passedNumberOfWeightsPerNeuron, passedActivationFunction)
        {
        }

        #endregion 

        #region Methods

        /// <summary>
        /// Populates <seealso cref="ANeuronLayer._Neurons">Neurons</seealso> with INeurons.
        /// </summary>
        protected override void CreateNeurons()
        {
            for (int i = 0; i < this.NumberOfNeurons; i++)
            {
                INeuron neuron = new Neuron(this.NumberOfWeightsPerNeuron, this.ActivationFunction);
                this._Neurons.Add(neuron);
            }
        }

        #endregion
    }
}
