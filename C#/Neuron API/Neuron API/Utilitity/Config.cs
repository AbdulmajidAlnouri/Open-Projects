using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neuron_API.Utilitity
{
    /// <summary>
    /// A Config Class containing all shared Data Members.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// A Singleton of <see cref="Random"/>.
        /// </summary>
        public static Random RANDOM = new Random();
    }
}
