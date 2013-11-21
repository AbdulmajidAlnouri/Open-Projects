using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Genetic_Neural_Network_API.Genetic_Neural_System_Models;

namespace Genetic_Neural_Network_API
{
    public class GeneticNeuralNetwork<T> : AGeneticNeuralNetwork<T> where T : IGeneticNeuralSystem
    {
        public GeneticNeuralNetwork(IEnumerable<T> passedPopulationMembers, uint passedChromosomeLength, float passedCrossOverRate, float passedMutationRate, bool storePastGenerations = true):base(passedPopulationMembers, passedChromosomeLength, passedCrossOverRate, passedMutationRate, storePastGenerations)
        {         
        }

    }
}
