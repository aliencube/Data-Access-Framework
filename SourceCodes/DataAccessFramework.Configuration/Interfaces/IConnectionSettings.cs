using System;

namespace DataAccessFramework.Configuration.Interfaces
{
    /// <summary>
    /// This provides interfaces to the ConnectionSettings class.
    /// </summary>
    public interface IConnectionSettings : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the collection of connection details.
        /// </summary>
        ConnectionDetailsElementCollection ConnectionDetails { get; set; }

        #endregion Properties
    }
}