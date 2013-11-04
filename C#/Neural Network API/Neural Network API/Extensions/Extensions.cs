using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neural_Network_API.Extensions
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

        #endregion
    }
}
