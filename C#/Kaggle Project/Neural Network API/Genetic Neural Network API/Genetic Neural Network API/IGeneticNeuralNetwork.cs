using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Genetic_Neural_Network_API.Genetic_Neural_System_Models;

namespace Genetic_Neural_Network_API
{
    public interface IGeneticNeuralNetwork<T> where T : IGeneticNeuralSystem
    {
        uint PopulationSize { get; }
        uint ChromoLength { get; }

        float AvgFitness { get; }
        float BestFitness { get; }
        float WorstFitness { get; }

        float MutationRate { get; }
        float CrossOverRate { get; }

        uint Generation { get; }


        IList<T> members { get; }

        void AdvanceGeneration();
        //IEnumerator<T> PreviousGenerations { get; }

    }
}
