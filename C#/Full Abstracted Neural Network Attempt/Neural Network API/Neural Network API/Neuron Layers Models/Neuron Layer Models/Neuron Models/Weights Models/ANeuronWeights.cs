using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models.Neuron_Weight_Model;

namespace Neural_Network_API.Neuron_Layers_Models.Neuron_Layer_Models.Neuron_Models.Weight_Models
{
    /// <summary>
    /// The abstract implementation of INeuronWeights.
    /// </summary>
    public abstract class ANeuronWeights : INeuronWeights
    {
        #region Data Members

        /// <summary>
        /// Backing field for Weights.
        /// </summary>
        protected List<INeuronWeight> _Weights;
        public IEnumerator<INeuronWeight> Weights
        {
            get { return this._Weights.GetEnumerator(); }
        }

        #endregion

        #region CTOR

        /// <summary>
        /// Initalizes an ANeuronWeights.
        /// </summary>
        /// <param name="passedNeuronWeights"></param>
        public ANeuronWeights(IEnumerable<INeuronWeight> passedNeuronWeights)
        {
            this._Weights = new List<INeuronWeight>(passedNeuronWeights);
        }

        #endregion
    }
}
