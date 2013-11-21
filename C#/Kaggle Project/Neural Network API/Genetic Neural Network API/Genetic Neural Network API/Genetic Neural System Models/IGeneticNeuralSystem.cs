using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API;

namespace Genetic_Neural_Network_API.Genetic_Neural_System_Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGeneticNeuralSystem
    {
        /// <summary>
        /// The number of problems solved correctly.
        /// </summary>
        float Correct { get; }

        /// <summary>
        /// The number of problems attempted.
        /// </summary>
        uint Attempts { get; }

        /// <summary>
        /// The Neural Network for the system.
        /// </summary>
        INeuralNetwork NeuralNetwork { get; }
        
        /// <summary>
        /// Calculates the average correctness. 
        /// </summary>
        /// <returns>The ratio of correctly solved problems over problems attempted.</returns>
        float CalculateFitness();
        
        /// <summary>
        /// Begins the Testing system where the system attempts to solve problems using the Neural Network.
        /// </summary>
        void Test();

        void Reset();
    }
}
