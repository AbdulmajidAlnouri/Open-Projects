using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Genetic_Neural_Network_API.Genetic_Neural_System_Models;
using Genetic_Neural_Network_API.Utilities;
using System.Diagnostics;
using Neural_Network_API;
using Neural_Network_API.Neuron_Layer_Models.Neuron_Models;
using Neural_Network_API.Neuron_Layer_Models;
using Neural_Network_API.Utilities;
namespace Genetic_Neural_Network_API
{
    public class AGeneticNeuralNetwork<T> : IGeneticNeuralNetwork<T> where T : IGeneticNeuralSystem
    {
        
        /// <summary>
        /// The backing field for PopulationSize.
        /// </summary>
        protected uint _PopulationSize;
        public uint PopulationSize
        {
            get { return this._PopulationSize; }
        }

        /// <summary>
        /// The backing field for ChromoLength.
        /// </summary>
        protected uint _ChromosomeLength;
        public uint ChromoLength
        {
            get { return this._ChromosomeLength; }
        }

        /// <summary>
        /// The backing field for AvgFitness.
        /// </summary>
        protected float _AvgFitness;
        public float AvgFitness
        {
            get { return this._AvgFitness; }
        }

        /// <summary>
        /// The backing field for BestFitness.
        /// </summary>
        protected float _BestFitness;
        public float BestFitness
        {
            get { return this._BestFitness; }
        }

        /// <summary>
        /// The backing field for WorstFitness.
        /// </summary>
        protected float _WorstFitness;
        public float WorstFitness
        {
            get { return this._WorstFitness; }
        }

        /// <summary>
        /// The backing field for MutationRate.
        /// </summary>
        protected float _MutationRate;
        public float MutationRate
        {
            get { return this._MutationRate; }
        }

        /// <summary>
        /// The backing field for CrossOverRate.
        /// </summary>
        protected float _CrossOverRate;
        public float CrossOverRate
        {
            get { return this._CrossOverRate; }
        }

        /// <summary>
        /// The backing field for Generation.
        /// </summary>
        protected uint _Generation;
        public uint Generation
        {
            get { return this._Generation; }
        }

        /// <summary>
        /// The backing field for PreviousGenerations.
        /// </summary>
        protected IList<IList<T>> _PreviousGenerations;

      

        protected IList<T> _CurrentPopulation;

        protected bool StorePastGenerations;




        public AGeneticNeuralNetwork(IEnumerable<T> passedPopulationMembers, uint passedChromosomeLength, float passedCrossOverRate, float passedMutationRate, bool storePastGenerations = true)
        {
            this._CurrentPopulation = new List<T>(passedPopulationMembers);
            this._ChromosomeLength = passedChromosomeLength;
            this._CrossOverRate = passedCrossOverRate;
            this._MutationRate = passedMutationRate;
            this._PopulationSize = (uint)passedPopulationMembers.Count();
        }




        public void AdvanceGeneration()
        {
            TestPopulation();

            //Sort the current population based on fitness. Copying must be done to convert from IOrderedEnumerable to a List.            

            List<T> alpha = _CurrentPopulation.OrderByDescending(x => x.CalculateFitness()).ToList();
            this._CurrentPopulation = new List<T>(alpha);
            

            //Calculate the Stats for the Current Generation.
            CalculateGenerationalStats();
            
            //Add the Current Generation to the Old Generation if StorePastGenerations is enabled.
            if (StorePastGenerations)
            {
                this._PreviousGenerations.Add(this._CurrentPopulation); 
            }

            Evolution(this._CurrentPopulation);
            foreach (var item in this._CurrentPopulation)
            {
                item.Reset();
            }
        }

        float PercentageToTx = 1.0f;

        protected void Evolution(IList<T> passedPopulation)
        {
                       
            //Create the new population.
            List<T> newPopulation = new List<T>(passedPopulation.Count);

            //The amount of top performing members to keep.
            uint amountOfMembersToPreserve = 1;// (uint)(passedPopulation.Count * PercentageToTx);
            
            //Take the Best X members from the passed population and add them to the new population. X:amountOfMembersToPerserve.
            newPopulation.AddRange(passedPopulation);

            //Assigns the current population using the new population.
            Repopulate(newPopulation, amountOfMembersToPreserve);

            //Increment Generational Counter
            this._Generation += 1;
        }

        private void TestPopulation()
        {
            foreach (T tElement in this._CurrentPopulation)
            {
                tElement.Test();
            }
        }


        protected void Repopulate(IList<T> passedExistingPopulation, uint startingPopulation)
        {    
            //Starting at X fill the remaining population members. X:The number of perserved members.
            for (int i = (int)startingPopulation; i < this.PopulationSize; i++)
            {
                T parentOneWeights = passedExistingPopulation.RandomElement(startingPopulation);//.NeuralNetwork.GetNeuronLayersWeights();
                T parentTwoWeights = passedExistingPopulation.RandomElement(startingPopulation);//.NeuralNetwork.GetNeuronLayersWeights();

                float[][][] childWeights = CreateChildWeights(parentOneWeights, parentTwoWeights); ;

                passedExistingPopulation[i].NeuralNetwork.SetNeuronLayersWeights(childWeights);

                float[][] thresholds = CreateChildThresholds(parentOneWeights, parentTwoWeights);
                passedExistingPopulation[i].NeuralNetwork.SetNeuronLayersThresholds(thresholds);
            }
            this._CurrentPopulation = passedExistingPopulation;
        }





        protected float[][] CreateChildThresholds(T parentOne, T parentTwo)
        {
            //[layer][neuron][threshold]
            float[][] parentOneWeights = parentOne.NeuralNetwork.GetNeuronLayersThresholds();
            float[][] parentTwoWeights = parentTwo.NeuralNetwork.GetNeuronLayersThresholds();

            float[][] childThresholds = CrossOver(parentOneWeights, parentTwoWeights);

            childThresholds = RandomMutation(childThresholds);


            return childThresholds;
        }
        
        protected float[][] RandomMutation(float[][] passedThresholds)
        {
            for (int i = 0; i < passedThresholds.Length; i++)
            {
                for (int j = 0; j < passedThresholds[i].Length; j++)
                {
                    
                        float mutate = Genetic_Neural_Network_API.Utilities.Config.RANDOM.NextFloat();

                        passedThresholds[i][j] = (mutate >= MutationRate) ?
                            passedThresholds[i][j] : Genetic_Neural_Network_API.Utilities.Config.RANDOM.NextFloat();                    
                }
            }
            return passedThresholds;
        }

        protected float[][] CrossOver(float[][] parentOneThresholds, float[][] parentTwoThresholds)
        {
            float[][] result = new float[parentOneThresholds.Length][];

            for (int layerIndex = 0; layerIndex < parentOneThresholds.Length; layerIndex++)
            {
                //Set the size of the Neuron Dimension for layer (layerIndex) to the same size as parent 1's Xth Layer Neuron Count. X:layerIndex.
                result[layerIndex] = new float[parentOneThresholds[layerIndex].Length];

                for (int neuronIndex = 0; neuronIndex < parentOneThresholds[layerIndex].Length; neuronIndex++)
                {
                    result[layerIndex][neuronIndex] =
                        (Genetic_Neural_Network_API.Utilities.Config.RANDOM.NextFloat() > .5) ?
                        parentOneThresholds[layerIndex][neuronIndex] :
                        parentTwoThresholds[layerIndex][neuronIndex];
                    
                }
            }
            return result;
        }



        protected float[][][] CreateChildWeights(T parentOne, T parentTwo)
        {
            //[layer][neuron][weights]
            float[][][] parentOneWeights = parentOne.NeuralNetwork.GetNeuronLayersWeights();
            float[][][] parentTwoWeights = parentTwo.NeuralNetwork.GetNeuronLayersWeights();

            float[][][] childWeights = CrossOver(parentOneWeights, parentTwoWeights);

            childWeights = RandomMutation(childWeights);


            return childWeights;        
        }

        protected float[][][] RandomMutation(float[][][] passedWeights)
        {
            for (int i = 0; i < passedWeights.Length; i++)
            {
                for (int j = 0; j < passedWeights[i].Length; j++)
                {
                    for (int k = 0; k < passedWeights[i][j].Length; k++)
                    {
                        float mutate = Genetic_Neural_Network_API.Utilities.Config.RANDOM.NextFloat();

                        passedWeights[i][j][k] = (mutate >= MutationRate) ?
                            passedWeights[i][j][k] : Genetic_Neural_Network_API.Utilities.Config.RANDOM.NextFloat();
                    }
                }
            }
            return passedWeights;
        }

        protected float[][][] CrossOver(float[][][] parentOneWeights, float[][][] parentTwoWeights)
        {

            float[][][] result = new float[parentOneWeights.Length][][];
            
            
            for (int layerIndex = 0; layerIndex < parentOneWeights.Length; layerIndex++)
            {
                //Set the size of the Neuron Dimension for layer (layerIndex) to the same size as parent 1's Xth Layer Neuron Count. X:layerIndex.
                result[layerIndex] = new float[parentOneWeights[layerIndex].Length][];

                for (int neuronIndex = 0; neuronIndex < parentOneWeights[layerIndex].Length; neuronIndex++)
                {
                    //Set the size of the Weight Dimension for the layer-neuron to the same as parent 1's.
                    result[layerIndex][neuronIndex] = new float[parentOneWeights[layerIndex][neuronIndex].Length];

                    //Select a Random Value between 0 and the Length (-1 because the max is exclusive). See Random.Next(int,int)
                    int crossPoint = Genetic_Neural_Network_API.Utilities.Config.RANDOM.Next(0, parentOneWeights[layerIndex][neuronIndex].Length);

                    for (int weightIndex = 0; weightIndex < parentOneWeights[layerIndex][neuronIndex].Length; weightIndex++)
                    {
                        //Select all Weights from parentOne until the cross point; at which take all weights from parentTwo.
                        result[layerIndex][neuronIndex][weightIndex] =
                            (weightIndex < crossPoint) ?
                            parentOneWeights[layerIndex][neuronIndex][weightIndex]:
                            parentTwoWeights[layerIndex][neuronIndex][weightIndex];
                    }
                }
            }
            return result;
        }



        protected void CalculateGenerationalStats()
        {
            this._BestFitness = this._CurrentPopulation.Max(x => x.CalculateFitness());
            this._WorstFitness = this._CurrentPopulation.Min(x => x.CalculateFitness());
            this._AvgFitness = (_BestFitness + _WorstFitness) / 2.0f;
        }









        public IList<T> members
        {
            get { return this._CurrentPopulation; }
        }
    }


}
