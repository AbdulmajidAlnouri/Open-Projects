using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API;

namespace Genetic_Neural_Network_API.Genetic_Neural_System_Models
{
    /// <summary>
    /// An Abstract class for a Genetic Neural System.
    /// </summary>
    public abstract class AGeneticNeuralSystem : IGeneticNeuralSystem
    {
        #region Data Members

        /// <summary>
        /// The backing field for Correct.
        /// </summary>
        protected float _Correct;
        
        /// <summary>
        /// The number of problems solved correctly.
        /// </summary>
        public float Correct
        {
            get { return this._Correct; }
        }

        /// <summary>
        /// The backing field for Attempts.
        /// </summary>
        protected uint _Attempts;

        /// <summary>
        /// The number of problems attempted.
        /// </summary>
        public uint Attempts
        {
            get { return this._Attempts; }
        }

        /// <summary>
        /// The backing field for NeuralNetwork.
        /// </summary>
        protected INeuralNetwork _neuralNetwork;
        
        /// <summary>
        /// The Neural Network for the system.
        /// </summary>
        public INeuralNetwork NeuralNetwork
        {
            get { return this._neuralNetwork; }
        }

        #endregion

        #region CTOR

        /// <summary>
        /// Initalizes an AGeneticNeuralSystem.
        /// </summary>
        /// <param name="passedNeuralNetwork">The Neural Network to use.</param>
        public AGeneticNeuralSystem(INeuralNetwork passedNeuralNetwork)
        {
            this._neuralNetwork = passedNeuralNetwork;
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Begins the Testing system where the system attempts to solve problems using the Neural Network.
        /// </summary>
        public abstract void Test();

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the average correctness. 
        /// </summary>
        /// <returns>The ratio of correctly solved problems over problems attempted.</returns>
        public float CalculateFitness()
        {
            float result = this._Correct / this._Attempts;
            return result;
        }

        #endregion


        public virtual void Reset()
        {
            this._Attempts = 0;
            this._Correct = 0;
        }
    }
}
