using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layer_Models.Neuron_Models.Activation_Function_Models;
using Neural_Network_API.Utilities;
namespace Neural_Network_API.Neuron_Layer_Models.Neuron_Models
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
        protected float _Threshold;

        /// <summary>
        /// The Threshold for the Neuron.
        /// </summary>
        public float Threshold
        {
            get { return this._Threshold; }
            set { this._Threshold = value; }
        }

        /// <summary>
        /// The backing field for Weights.
        /// </summary>
        protected float[] _Weights;

        /// <summary>
        /// The Weights for the Neuron.
        /// </summary>
        public float[] Weights
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
            this._Weights = new float[passedNumberOfWeights];
            this._ActivationFunction = passedActivationFunction;

            InitalizeWeights();

            this._Threshold = Config.RANDOM.NextFloat();
        }

        /// Initalizes an ANeuron.
        /// </summary>
        /// <param name="passedNumberOfWeights">The Number of Weights for the Neuron.</param>
        /// <param name="passedThreshold">The Threshold for the Neuron.</param>
        /// <param name="passedActivationFunction">The Activation Function for the Neuron</param>
        public ANeuron(uint passedNumberOfWeights, float passedThreshold, IActivationFunction passedActivationFunction)
        {
            this._Weights = new float[passedNumberOfWeights];
            this._ActivationFunction = passedActivationFunction;

            InitalizeWeights();

            this._Threshold = passedThreshold;
        }

        #endregion CTOR

        #region Methods

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
        public float CalculateOutput(float[] passedInputs)
        {
            float total = 0.0f;

            for (int i = 0; i < passedInputs.Length; i++)
            {
                float tempValue = this.Weights[i] * passedInputs[i];
                total += tempValue;
            }

            float result = this.ActivationFunction.CalculateOutput(total, this.Threshold);
            return result;
        }

        #endregion
    }
}
