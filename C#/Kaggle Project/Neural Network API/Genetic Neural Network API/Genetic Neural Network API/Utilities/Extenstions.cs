using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genetic_Neural_Network_API.Utilities
{
    public static class Extensions
    {
        public static T RandomElement<T>(this IEnumerable<T> iEnumerable)
        {
            T result;

            //Get a random index to pull from.
            uint randomElementIndex = (uint)Config.RANDOM.Next(iEnumerable.Count());

            //Select the element at the X index and assign it to result. X:randomElementIndex.
            result = iEnumerable.ElementAt((int)randomElementIndex);

            return result;        
        }
        
        public static T RandomElement<T>(this IEnumerable<T> enumerable, uint passedUpperRange)
        {
            //Store the size of the IEnumerable.
            int enumerableCount = enumerable.Count();

            //If passedUpperRange is greater than the count of IEnumerable then throw an ArgumentOutOfRangeException.
            if (passedUpperRange > enumerableCount)
            {
                throw new ArgumentOutOfRangeException("passedUpperRange: " + passedUpperRange + " is greater than the count of the IEnumerable.");
            }

            //The result to return.
            T result;

            //Get a random index to pull from.
            uint randomElementIndex = (uint)Config.RANDOM.Next(enumerableCount);

            //Select the element at the X index and assign it to result. X:randomElementIndex.
            result = enumerable.ElementAt((int)randomElementIndex);

            //Return the result.
            return result;
        }

        
    }
}
