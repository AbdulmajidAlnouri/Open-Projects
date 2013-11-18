using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Member_Wrapper_API.Values_Models;
using Neuron_API.Neurons_Models.Neuron_Models;
using Neuron_API.Neurons_Models.Neurons_Activation_Functions_Models;
using Neuron_API.Neurons_Models.Neurons_Weights_Models;
using Neuron_API.Neurons_Models.Neurons_Threshold_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Threshold_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Weights_Models;
using Neuron_API.Neurons_Models.Neurons_Neuron_Outputs_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Inputs_Models;
using Neuron_API.Neurons_Models.Neuron_Models.Neuron_Activation_Function_Models;

namespace Neuron_API.Neurons_Models
{
    public class ANeurons : ListValues<INeuron>, INeurons
    {


        public ANeurons(IEnumerable<INeuron> passedNeurons):base(passedNeurons)
        {
        }

        public INeuronsThresholds GetNeuronsThresholds()
        {
            IList<INeuronThreshold> neuronThresholds = new List<INeuronThreshold>(this._Values.Count);
            IEnumerator<INeuron> neuronThresholdEnumerator = this.Values;
            while (neuronThresholdEnumerator.MoveNext())
            {
                INeuron currentNeuron = neuronThresholdEnumerator.Current;
                neuronThresholds.Add(currentNeuron.Threshold);                
            }
            INeuronsThresholds result = new NeuronsThresholds(neuronThresholds);
            return result;
        }

        public void SetNeuronsThresholds(INeuronsThresholds passedNeuronsThresholds)
        {
            Action<INeuron, INeuronThreshold> assignmentDelegate = (neuron, threshold) => neuron.Threshold = threshold;
            SetNeuronsType<INeuronsThresholds, INeuronThreshold>(passedNeuronsThresholds, assignmentDelegate);              
        }

        public INeuronsWeights GetNeuronsWeights()
        {
            IList<INeuronWeights> neuronWeights = new List<INeuronWeights>(this._Values.Count);
            IEnumerator<INeuron> neuronWeightsEnumerator = this.Values;
            while (neuronWeightsEnumerator.MoveNext())
            {
                INeuron currentNeuron = neuronWeightsEnumerator.Current;
                neuronWeights.Add(currentNeuron.Weights);
            }
            INeuronsWeights result = new NeuronsWeights(neuronWeights);
            return result;
        }

        public void SetNeuronsWeights(INeuronsWeights passedNeuronsWeights)
        {
            Action<INeuron, INeuronWeights> assignmentDelegate = (neuron, weights) => neuron.Weights = weights;
            SetNeuronsType<INeuronsWeights, INeuronWeights>(passedNeuronsWeights, assignmentDelegate);
        }

        public INeuronsNeuronActivationFunctions GetNeuronsNeuronActivationFunctions()
        {
            Action<INeuron, INeuronActivationFunction> a = (n, t) => n.ActivationFunction = t;
            return null;
        }

        public void SetNeuronsNeuronActivationFunctions(INeuronsNeuronActivationFunctions passedNeuronsNeuronActivationFunctions)
        {
            Action<INeuron, INeuronActivationFunction> assignmentDelegate = (neuron, NeuronActivationFunction) => neuron.ActivationFunction = NeuronActivationFunction;
            SetNeuronsType<INeuronsNeuronActivationFunctions, INeuronActivationFunction>(passedNeuronsNeuronActivationFunctions, assignmentDelegate);                     
        }

        public INeuronsNeuronOutput CalculateNeuronsOutput(INeuronInputs passedNeuronInputs)
        {
            throw new NotImplementedException();
        }


        protected TWrapper GetNeuronsThresholds<TWrapper, T>(Func<INeuron, T> retrivalFunction, Func<IList<T>, TWrapper> TWrapperCreationFunction) where TWrapper:IValues<T>
        {
            IList<T> neuronThresholds = new List<T>(this._Values.Count);
            IEnumerator<INeuron> neuronThresholdEnumerator = this.Values;
            while (neuronThresholdEnumerator.MoveNext())
            {
                INeuron currentNeuron = neuronThresholdEnumerator.Current;
                T retrievedValue = retrivalFunction(currentNeuron);
                neuronThresholds.Add(retrievedValue);
            }
            TWrapper result = TWrapperCreationFunction(neuronThresholds);
            return result;
        }
        
        protected void SetNeuronsType<TWrapper, T>(TWrapper passedNeuronsTWrapper, Action<INeuron, T> passedAssignmentDelegate) where TWrapper:IValues<T>
        {
            IEnumerator<T> passedNeuronsTEnumerator = passedNeuronsTWrapper.Values;
            uint neuronIndex = 0;
            while (passedNeuronsTEnumerator.MoveNext())
            {
                INeuron neuron = this._Values[(int)neuronIndex++];
                T currentNeuronWeights = passedNeuronsTEnumerator.Current;
                passedAssignmentDelegate.Invoke(neuron, currentNeuronWeights);                
            }
        }




    }
}
