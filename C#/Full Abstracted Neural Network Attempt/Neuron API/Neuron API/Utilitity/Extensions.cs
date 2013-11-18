using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuron_API.Utilitity
{
    /// <summary>
    /// Extension Methods.
    /// </summary>
    public static class Extensions
    {
        #region Methods

        /// <summary>
        /// Creates a Random Float between 0 and 1 Inclusive.
        /// </summary>
        /// <param name="random">The Random instance.</param>
        /// <returns>A Random Float between 0 and 1 Inclusive.</returns>
        public static float NextFloat(this Random random)
        {
            float result = (float)random.NextDouble();
            return result;
        }

        //public static uint TotalNumberOfNeurons(this IEnumerator<INeuronLayer> neuronLayerEnumerator)
        //{
        //    neuronLayerEnumerator.Reset();
        //    uint result = 0;
        //
        //    while (neuronLayerEnumerator.MoveNext())
        //    {
        //        INeuronLayer currentNeuronLayer = neuronLayerEnumerator.Current;
        //        result += currentNeuronLayer.NumberOfNeurons;
        //    }
        //    return result;
        //}
        //
        //public static uint TotalNumberOfWeights(this IEnumerator<INeuronLayer> neuronLayerEnumerator)
        //{
        //    neuronLayerEnumerator.Reset();
        //    uint result = 0;
        //
        //    while (neuronLayerEnumerator.MoveNext())
        //    {
        //        INeuronLayer currentNeuronLayer = neuronLayerEnumerator.Current;
        //        result += currentNeuronLayer.NumberOfNeurons * currentNeuronLayer.NumberOfWeightsPerNeuron;
        //    }
        //    return result;
        //}

        #endregion
    }
}
