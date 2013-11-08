using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Output_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Inputs_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Weights_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Threshold_Models;
using Neuron_API.Utilitity;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Weights_Models.Neuron_Weight_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Inputs_Models.Neuron_Input_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models.Neuron_Activation_Function_Input_Models;

namespace Neuron_API.Neurons_Models.Neuron_Models
{
    public class ANeuron : INeuron
    {

        protected INeuronThreshold _Threshold;
        public INeuronThreshold Threshold
        {
            get
            {
                return this._Threshold;
            }
            set
            {
                this._Threshold = value;
            }
        }

        protected INeuronWeights _Weights;
        public INeuronWeights Weights
        {
            get
            {
                return this._Weights;
            }
            set
            {
                this._Weights = value;
            }
        }

        protected INeuronActivationFunction _ActivationFunction;
        public INeuronActivationFunction ActivationFunction
        {
            get { return this._ActivationFunction; }
        }










        public ANeuron(uint passedNumberOfWeights, INeuronActivationFunction passedActivationFunction)
        {
            this._Weights = GenerateWeights(passedNumberOfWeights);
            this._ActivationFunction = passedActivationFunction;       
            this._Threshold = new NeuronThreshold(Config.RANDOM.NextFloat());
        }

        public ANeuron(uint passedNumberOfWeights, INeuronThreshold passedThreshold, INeuronActivationFunction passedActivationFunction)
        {
            this._Weights = GenerateWeights(passedNumberOfWeights);
            this._ActivationFunction = passedActivationFunction;
            this._Threshold = passedThreshold;
        }

        public ANeuron(INeuronWeights passedNeuronWeights, INeuronActivationFunction passedActivationFunction)
        {
            this.Weights = passedNeuronWeights;
            this._ActivationFunction = passedActivationFunction;
            this.Threshold = new NeuronThreshold(Config.RANDOM.NextFloat());
        }

        public ANeuron(INeuronWeights passedNeuronWeights, INeuronThreshold passedThreshold, INeuronActivationFunction passedActivationFunction)
        {
            this.Weights = passedNeuronWeights;
            this._ActivationFunction = passedActivationFunction;
            this.Threshold = passedThreshold;
        }









        #region Methods


        protected INeuronWeights GenerateWeights(uint passedNumberOfWeights)
        {
            IList<INeuronWeight> WeightsList = new List<INeuronWeight>((int)passedNumberOfWeights);
            for (int i = 0; i < passedNumberOfWeights; i++)
            {
                WeightsList.Add(CreateRandomNeuronWeight());
            }

            INeuronWeights result = new NeuronWeights(WeightsList);
            return result;
        }
     
        protected INeuronWeight CreateRandomNeuronWeight()
        {
            float randomWeight = Config.RANDOM.NextFloat();
            INeuronWeight result = new NeuronWeight(randomWeight);
            return result;
        }
            

        public INeuronOutput CalculateOutput(INeuronInputs passedInputs)
        {
            float total = 0.0f;

            IEnumerator<INeuronWeight> neuronWeightsEnumerator = this.Weights.Values;
            IEnumerator<INeuronInput> neuronInputsEnumerator = passedInputs.Values;
            while (neuronWeightsEnumerator.MoveNext() && neuronInputsEnumerator.MoveNext())
            {
                INeuronWeight currentWeight = neuronWeightsEnumerator.Current;
                INeuronInput currentInput = neuronInputsEnumerator.Current;
                float tempValue = currentWeight.Value * currentInput.Value;
                total += tempValue;
            }

            INeuronActivationFunctionInput neuronActivationInput = new NeuronActivationFunctionInput(total);
            INeuronOutput result = this.ActivationFunction.CalculateOutput(neuronActivationInput, this.Threshold);
            return result;
        }

        #endregion
   
    }
}
