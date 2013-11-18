using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;
using Neural_Network_API.Utilities;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models.Neuron_Weight_Model;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Threshold_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Outputs_Models.Neuron_Output_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Neuron_Inputs_Models.Neuron_Input_Models;
namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models
{
    /// <summary>
    /// The Abstract class for a Neuron.
    /// </summary>
    public abstract class ANeuron : INeuron
    {

        #region Data Members

        /// <summary>
        /// The backing field for Threshold.
        /// </summary>
        protected INeuronThreshold _Threshold;

        /// <summary>
        /// The Threshold for the Neuron.
        /// </summary>
        public INeuronThreshold Threshold
        {
            get { return this._Threshold; }
            set { this._Threshold = value; }
        }

        /// <summary>
        /// The backing field for Weights.
        /// </summary>
        protected INeuronWeights _Weights;

        /// <summary>
        /// The Weights for the Neuron.
        /// </summary>
        public INeuronWeights Weights
        {
            get { return this._Weights; }
            set { this._Weights = value; }
        }

        /// <summary>
        /// The backing field for Weights.
        /// </summary>
        protected IActivationFunction _ActivationFunction;

        /// <summary>
        /// The Activation Function of the Neuron.
        /// </summary>
        public IActivationFunction ActivationFunction
        {
            get { return this._ActivationFunction; }
        }

        #endregion

        #region CTOR

        /// <summary>
        /// Initalizes an ANeuron.
        /// Notes:
        ///     -Initalizes Threshold to a Random Float.
        /// </summary>
        /// <param name="passedNumberOfWeights">The Number of Weights for the Neuron.</param>
        /// <param name="passedActivationFunction">The Activation Function for the Neuron</param>
        public ANeuron(uint passedNumberOfWeights, IActivationFunction passedActivationFunction)
        {
            this._Weights = GenerateWeights(passedNumberOfWeights);          
            this._ActivationFunction = passedActivationFunction;

            InitalizeWeights();

            this._Threshold = new NeuronThreshold(Config.RANDOM.NextFloat());
        }

        private INeuronWeights GenerateWeights(uint passedNumberOfWeights)
        {            
            IList<INeuronWeight> WeightsList = new List<INeuronWeight>((int)passedNumberOfWeights);
            for (int i = 0; i < passedNumberOfWeights; i++)
            {
                WeightsList.Add(CreateRandomNeuronWeight());
            }

            INeuronWeights result = new NeuronWeights(WeightsList);
            return result;
        }

       

        /// Initalizes an ANeuron.
        /// </summary>
        /// <param name="passedNumberOfWeights">The Number of Weights for the Neuron.</param>
        /// <param name="passedThreshold">The Threshold for the Neuron.</param>
        /// <param name="passedActivationFunction">The Activation Function for the Neuron</param>
        public ANeuron(uint passedNumberOfWeights, float passedThreshold, IActivationFunction passedActivationFunction)
        {
            this._Weights = GenerateWeights(passedNumberOfWeights);
            this._ActivationFunction = passedActivationFunction;

            InitalizeWeights();

            this._Threshold = passedThreshold;
        }



        #endregion CTOR

        #region Methods

        /// <summary>
        /// Generates an INeuronWeight with a random wrapped value.
        /// </summary>
        /// <returns>An INeuronWeight with a random value.</returns>
        protected INeuronWeight CreateRandomNeuronWeight()
        {
            INeuronWeight result = new NeuronWeight(Config.RANDOM.NextFloat());
            return result;
        }

        /// <summary>
        /// Initalizes Weights to Random Float values.
        /// </summary>
        protected void InitalizeWeights()
        {
            for (int i = 0; i < this._Weights.Length; i++)
            {
                this._Weights[i] = Config.RANDOM.NextFloat();
            }
        }

        /// <summary>
        /// Calculates the Output for the Neuron given the Input.
        /// </summary>
        /// <param name="passedInput">The Input for the Neuron.</param>
        /// <returns>The Output of the Neuron.</returns>
        public INeuronOutput CalculateOutput(INeuronInputs passedInputs)
        {
            float total = 0.0f;

            IEnumerator<INeuronWeight> neuronWeightsEnumerator = this.Weights.Weights;
            IEnumerator<INeuronInput> neuronInputsEnumerator = passedInputs.Values;
            while (neuronWeightsEnumerator.MoveNext() && neuronInputsEnumerator.MoveNext())
            {
                INeuronWeight currentWeight = neuronWeightsEnumerator.Current;
                INeuronInput currentInput = neuronInputsEnumerator.Current;
                float tempValue = currentWeight.Value * currentInput.Value;
                total += tempValue;
            }

            float computedResult = this.ActivationFunction.CalculateOutput(total, this.Threshold);
            INeuronOutput result = new NeuronOutput(computedResult);
            return result;
        }

        #endregion
    }
}
