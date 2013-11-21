using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neural_Network_API.Utilities.Value_Models
{
    /// <summary>
    /// An abstract T wrapper IValue.
    /// </summary>
    /// <typeparam name="T">The type to wrap.</typeparam>
    public class AValue<T> : IValue<T>
    {

        #region Data Members

        /// <summary>
        /// The backing field for Value.
        /// </summary>
        protected T _Value;

        /// <summary>
        /// Stores the wrapped value.
        /// </summary>
        public T Value
        {
            get { return this._Value; }
        }

        #endregion

        #region CTOR

        /// <summary>
        /// Initalizes an AValue.
        /// </summary>
        /// <param name="passedValue">The value to store.</param>
        public AValue(T passedValue)
        {
            this._Value = passedValue;
        }

        #endregion
    }
}
